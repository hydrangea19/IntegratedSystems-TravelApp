﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IActionResult> Index()
        {
            var activities = await _activityService.GetAllActivitiesAsync();
            return View(activities);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _activityService.GetActivityByIdAsync(id.Value);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Date,Location,Cost,DurationHours")] ActivityDTO activityDto)
        {
            if (ModelState.IsValid)
            {
                await _activityService.AddActivityAsync(activityDto);
                return RedirectToAction(nameof(Index));
            }
            return View(activityDto);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _activityService.GetActivityByIdAsync(id.Value);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Date,Location,Cost,DurationHours")] ActivityDTO activityDto)
        {
            if (id != activityDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _activityService.UpdateActivityAsync(activityDto);
                return RedirectToAction(nameof(Index));
            }
            return View(activityDto);
        }

       
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _activityService.GetActivityByIdAsync(id.Value);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _activityService.DeleteActivityAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
