using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Service.Interface
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>> GetAllActivitiesAsync();
        Task<ActivityDTO> GetActivityByIdAsync(int id);
        Task AddActivityAsync(ActivityDTO activityDto);
        Task UpdateActivityAsync(ActivityDTO activityDto);
        Task DeleteActivityAsync(int id);
    }
}
