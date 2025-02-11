using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;
using TravelApplication.Service.Implementation;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    public class TransportsController : Controller
    {
        private readonly ITransportService _transportService;

        public TransportsController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        // GET: Transports
        public async Task<IActionResult> Index()
        {
            var transports = await _transportService.GetAllTransportsAsync();
            return View(transports);
        }

        // GET: Transports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _transportService.GetTransportByIdAsync(id.Value);
            if (transport == null)
            {
                return NotFound();
            }

            return View(transport);
        }

        // GET: Transports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,DeparturePoint,ArrivalPoint,DepartureTime,ArrivalTime,CostPerPassenger")] TransportDTO transportDto)
        {
            if (ModelState.IsValid)
            {
                await _transportService.AddTransportAsync(transportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(transportDto);
        }

        // GET: Transports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _transportService.GetTransportByIdAsync(id.Value);
            if (transport == null)
            {
                return NotFound();
            }
            return View(transport);
        }

        // POST: Transports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,DeparturePoint,ArrivalPoint,DepartureTime,ArrivalTime,CostPerPassenger")] TransportDTO transportDto)
        {
            if (id != transportDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _transportService.UpdateTransportAsync(transportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(transportDto);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _transportService.GetTransportByIdAsync(id.Value);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transportService.DeleteTransportAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
