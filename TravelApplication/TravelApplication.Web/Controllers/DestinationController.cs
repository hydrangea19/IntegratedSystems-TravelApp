using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository;

namespace TravelApplication.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _context.Destinations
                .Select(d => new DestinationDTO
                {
                    TravelId = d.TravelId,
                    Name = d.Name,
                    Country = d.Country,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    Price = d.Price 
                })
                .ToListAsync();

            return View(destinations);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations
                .Include(d => d.Accommodations)
                .Include(d => d.DestinationActivities).ThenInclude(da => da.Activity) 
                .Include(d => d.DestinationTransports).ThenInclude(dt => dt.Transport) 
                .FirstOrDefaultAsync(m => m.TravelId == id);

            if (destination == null) return NotFound();

            Console.WriteLine("Destination: " + destination.Name);
            Console.WriteLine("Activities Count: " + destination.DestinationActivities.Count);
            Console.WriteLine("Transports Count: " + destination.DestinationTransports.Count);

            var destinationDTO = new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                Price = destination.Price,
                Accommodations = destination.Accommodations.Select(a => new AccommodationDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    price = a.Price,
                    DestinationId = a.DestinationId
                }).ToList(),
                Activities = destination.DestinationActivities.Select(da => new ActivityDTO
                {
                    Id = da.Activity.Id,
                    Name = da.Activity.Name,
                    Description = da.Activity.Description,
                    Date = da.Activity.Date,
                    Location = da.Activity.Location,
                    Cost = da.Activity.Cost,
                    DurationHours = da.Activity.DurationHours
                }).ToList(),
                Transports = destination.DestinationTransports.Select(dt => new TransportDTO
                {
                    Id = dt.Transport.Id,
                    Type = dt.Transport.Type,
                    DeparturePoint = dt.Transport.DeparturePoint,
                    ArrivalPoint = dt.Transport.ArrivalPoint,
                    DepartureTime = dt.Transport.DepartureTime,
                    ArrivalTime = dt.Transport.ArrivalTime,
                    CostPerPassenger = dt.Transport.CostPerPassenger
                }).ToList()
            };

            return View(destinationDTO);
        }

        public IActionResult Create()
        {
            ViewBag.Activities = new SelectList(_context.Activities, "Id", "Name"); // ✅ Allow selecting Activities
            ViewBag.Transports = new SelectList(_context.Transports, "Id", "Type"); // ✅ Allow selecting Transport
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationDTO destinationDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Activities = new SelectList(_context.Activities, "Id", "Name");
                ViewBag.Transports = new SelectList(_context.Transports, "Id", "Type");
                return View(destinationDto);
            }

            var destination = new Destination
            {
                TravelId = Guid.NewGuid(),
                Name = destinationDto.Name,
                Country = destinationDto.Country,
                Description = destinationDto.Description,
                ImageUrl = destinationDto.ImageUrl,
                Price = destinationDto.Price,
                DestinationActivities = destinationDto.SelectedActivityIds.Select(id => new DestinationActivity
                {
                    ActivityId = id
                }).ToList(),
                DestinationTransports = destinationDto.SelectedTransportIds.Select(id => new DestinationTransport
                {
                    TransportId = id
                }).ToList()
            };

            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations
                .Include(d => d.DestinationActivities)
                .Include(d => d.DestinationTransports)
                .FirstOrDefaultAsync(d => d.TravelId == id);

            if (destination == null) return NotFound();

            var destinationDto = new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                Price = destination.Price,
                Activities = destination.DestinationActivities.Select(da => new ActivityDTO
                {
                    Id = da.Activity.Id,
                    Name = da.Activity.Name,
                    Description = da.Activity.Description,
                    Date = da.Activity.Date,
                    Location = da.Activity.Location,
                    Cost = da.Activity.Cost,
                    DurationHours = da.Activity.DurationHours
                }).ToList(),
                Transports = destination.DestinationTransports.Select(dt => new TransportDTO
                {
                    Id = dt.Transport.Id,
                    Type = dt.Transport.Type,
                    DeparturePoint = dt.Transport.DeparturePoint,
                    ArrivalPoint = dt.Transport.ArrivalPoint,
                    DepartureTime = dt.Transport.DepartureTime,
                    ArrivalTime = dt.Transport.ArrivalTime,
                    CostPerPassenger = dt.Transport.CostPerPassenger
                }).ToList()
            };

            ViewBag.Activities = new SelectList(_context.Activities, "Id", "Name", destinationDto.Activities.Select(a => a.Id));
            ViewBag.Transports = new SelectList(_context.Transports, "Id", "Type", destinationDto.Transports.Select(t => t.Id));
            return View(destinationDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DestinationDTO destinationDto)
        {
            if (id != destinationDto.TravelId) return NotFound();

            if (ModelState.IsValid)
            {
                var destination = await _context.Destinations
                    .Include(d => d.DestinationActivities)
                    .Include(d => d.DestinationTransports)
                    .FirstOrDefaultAsync(d => d.TravelId == id);

                if (destination == null) return NotFound();

                destination.Name = destinationDto.Name;
                destination.Country = destinationDto.Country;
                destination.Description = destinationDto.Description;
                destination.ImageUrl = destinationDto.ImageUrl;
                destination.Price = destinationDto.Price;

                var existingActivityIds = destination.DestinationActivities.Select(da => da.ActivityId).ToList();
                var selectedActivityIds = destinationDto.SelectedActivityIds;

                foreach (var activityId in existingActivityIds.Except(selectedActivityIds))
                {
                    var activityToRemove = destination.DestinationActivities.FirstOrDefault(da => da.ActivityId == activityId);
                    if (activityToRemove != null)
                    {
                        destination.DestinationActivities.Remove(activityToRemove);
                    }
                }

                foreach (var activityId in selectedActivityIds.Except(existingActivityIds))
                {
                    destination.DestinationActivities.Add(new DestinationActivity { ActivityId = activityId });
                }

                var existingTransportIds = destination.DestinationTransports.Select(dt => dt.TransportId).ToList();
                var selectedTransportIds = destinationDto.SelectedTransportIds;

                foreach (var transportId in existingTransportIds.Except(selectedTransportIds))
                {
                    var transportToRemove = destination.DestinationTransports.FirstOrDefault(dt => dt.TransportId == transportId);
                    if (transportToRemove != null)
                    {
                        destination.DestinationTransports.Remove(transportToRemove);
                    }
                }

                foreach (var transportId in selectedTransportIds.Except(existingTransportIds))
                {
                    destination.DestinationTransports.Add(new DestinationTransport { TransportId = transportId });
                }

                _context.Update(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Activities = new SelectList(_context.Activities, "Id", "Name", destinationDto.SelectedActivityIds);
            ViewBag.Transports = new SelectList(_context.Transports, "Id", "Type", destinationDto.SelectedTransportIds);
            return View(destinationDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations.FirstOrDefaultAsync(m => m.TravelId == id);
            if (destination == null) return NotFound();

            var destinationDTO = new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description
            };

            return View(destinationDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination == null) return NotFound();

            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
