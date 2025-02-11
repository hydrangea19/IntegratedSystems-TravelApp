using Microsoft.AspNetCore.Mvc;
using TravelApplication.Service.Interface;
using TravelApplication.Service.Interfaces;
using TravelApplication.Domain.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TravelApplication.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IAccommodationService _accommodationService;
        private readonly ITransportService _transportService;
        private readonly IActivityService _activityService;

        public AdminController(IDestinationService destinationService,
                               IAccommodationService accommodationService,
                               ITransportService transportService,
                               IActivityService activityService)
        {
            _destinationService = destinationService;
            _accommodationService = accommodationService;
            _transportService = transportService;
            _activityService = activityService;
        }

        // GET: Admin/Destinations
        public async Task<IActionResult> Destinations()
        {
            var destinations = await _destinationService.GetAllAsync();
            return View(destinations);
        }

        // GET: Admin/Accommodations
        public async Task<IActionResult> Accommodations()
        {
            var accommodations = await _accommodationService.GetAllAsync();
            return View(accommodations);
        }

        // GET: Admin/Transports
        public async Task<IActionResult> Transports()
        {
            var transports = await _transportService.GetAllTransportsAsync();
            return View(transports);
        }

        // GET: Admin/Activities
        public async Task<IActionResult> Activities()
        {
            var activities = await _activityService.GetAllActivitiesAsync();
            return View(activities);
        }
    }
}
