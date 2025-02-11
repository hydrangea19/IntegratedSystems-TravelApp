using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;
using TravelApplication.Domain.Domain;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<ActivityDTO>> GetAllActivitiesAsync()
        {
            var activities = await _activityRepository.GetAllAsync();
            return activities.Select(a => new ActivityDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Date = a.Date,
                Location = a.Location,
                Cost = a.Cost,
                DurationHours = a.DurationHours
            });
        }

        public async Task<ActivityDTO> GetActivityByIdAsync(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null)
            {
                return null;
            }

            return new ActivityDTO
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                Date = activity.Date,
                Location = activity.Location,
                Cost = activity.Cost,
                DurationHours = activity.DurationHours
            };
        }

        public async Task AddActivityAsync(ActivityDTO activityDto)
        {
            var activity = new Activity
            {
                Name = activityDto.Name,
                Description = activityDto.Description,
                Date = activityDto.Date,
                Location = activityDto.Location,
                Cost = activityDto.Cost,
                DurationHours = activityDto.DurationHours
            };

            await _activityRepository.AddAsync(activity);
        }

        public async Task UpdateActivityAsync(ActivityDTO activityDto)
        {
            var activity = await _activityRepository.GetByIdAsync(activityDto.Id);
            if (activity == null) return;

            activity.Name = activityDto.Name;
            activity.Description = activityDto.Description;
            activity.Date = activityDto.Date;
            activity.Location = activityDto.Location;
            activity.Cost = activityDto.Cost;
            activity.DurationHours = activityDto.DurationHours;

            await _activityRepository.UpdateAsync(activity);
        }

        public async Task DeleteActivityAsync(int id)
        {
            await _activityRepository.DeleteAsync(id);
        }
    }
}
