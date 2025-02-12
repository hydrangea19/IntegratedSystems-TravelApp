using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Service.Interface
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>> GetAllActivitiesAsync();
        Task<ActivityDTO> GetActivityByIdAsync(Guid id); // Changed from int to Guid
        Task AddActivityAsync(ActivityDTO activityDto);
        Task UpdateActivityAsync(ActivityDTO activityDto);
        Task DeleteActivityAsync(Guid id); // Changed from int to Guid
    }
}