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

        public async Task<IActionResult> Index()
        {
            var transports = await _transportService.GetAllTransportsAsync();
            return View(transports);
        }

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

        public IActionResult Create()
        {
            return View();
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Type,DeparturePoint,ArrivalPoint,DepartureTime,ArrivalTime,CostPerPassenger")] TransportDTO transportDto)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transportService.DeleteTransportAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
