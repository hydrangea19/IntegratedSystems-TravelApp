using Microsoft.AspNetCore.Mvc;
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
                    Description = d.Description
                })
                .ToListAsync();

            return View(destinations);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations
                .Include(d => d.Accomodations)
                .FirstOrDefaultAsync(m => m.TravelId == id);

            if (destination == null) return NotFound();

            // Map Destination to DestinationDTO
            var destinationDTO = new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                Accommodations = destination.Accomodations.Select(a => new AccommodationDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    price = a.Price,
                    DestinationId = a.DestinationId
                }).ToList()
            };

            return View(destinationDTO);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Country,Description")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                destination.TravelId = Guid.NewGuid();
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations.FindAsync(id);
            if (destination == null) return NotFound();

            // Map Destination to DestinationDTO
            var destinationDTO = new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description
            };

            return View(destinationDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TravelId,Name,Country,Description")] Destination destination)
        {
            if (id != destination.TravelId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.TravelId == id);

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
