using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelApplication.Repository;
using TravelApplication.Domain.Domain;
using TravelApplication.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApplication.Web.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccommodationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var accommodations = await _context.Accommodations
                .Include(a => a.Destination) 
                .Select(a => new AccommodationDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    price = a.Price,
                    DestinationId = a.DestinationId
                })
                .ToListAsync();

            return View(accommodations);
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .Include(a => a.Destination)
                .Select(a => new AccommodationDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    price = a.Price,
                    DestinationId = a.DestinationId
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

       
        public IActionResult Create()
        {
            var destinations = _context.Destinations.ToList();

            if (destinations.Count == 0)
            {
                TempData["Error"] = "No destinations available. Please create a destination first.";
                return RedirectToAction("Index", "Destinations");
            }

            ViewBag.Destinations = new SelectList(destinations, "TravelId", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,price,DestinationId")] AccommodationDTO accommodationDto)
        {
            if (ModelState.IsValid)
            {
                var accommodation = new Accommodation
                {
                    Name = accommodationDto.Name,
                    Type = accommodationDto.Type,
                    Price = accommodationDto.price,
                    DestinationId = accommodationDto.DestinationId
                };

                _context.Accommodations.Add(accommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewBag.Destinations = new SelectList(_context.Destinations, "TravelId", "Name", accommodationDto.DestinationId);
            return View(accommodationDto);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            var accommodationDto = new AccommodationDTO
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Type = accommodation.Type,
                price = accommodation.Price,
                DestinationId = accommodation.DestinationId
            };

            ViewBag.Destinations = new SelectList(_context.Destinations, "TravelId", "Name", accommodationDto.DestinationId); // ✅ Ensure dropdown appears
            return View(accommodationDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,price,DestinationId")] AccommodationDTO accommodationDto)
        {
            if (id != accommodationDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var accommodation = await _context.Accommodations.FindAsync(id);
                    if (accommodation == null)
                    {
                        return NotFound();
                    }

                    accommodation.Name = accommodationDto.Name;
                    accommodation.Type = accommodationDto.Type;
                    accommodation.Price = accommodationDto.price;
                    accommodation.DestinationId = accommodationDto.DestinationId;

                    _context.Update(accommodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Accommodations.Any(e => e.Id == accommodationDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Destinations = new SelectList(_context.Destinations, "TravelId", "Name", accommodationDto.DestinationId); // ✅ Keep dropdown populated
            return View(accommodationDto);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .Include(a => a.Destination) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accommodation == null)
            {
                return NotFound();
            }

            var accommodationDto = new AccommodationDTO
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Type = accommodation.Type,
                price = accommodation.Price,
                DestinationId = accommodation.DestinationId
            };

            return View(accommodationDto);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AccommodationExists(int id)
        {
            return _context.Accommodations.Any(e => e.Id == id);
        }
    }
}
