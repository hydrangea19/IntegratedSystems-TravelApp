using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelApplication.Domain.Domain;

namespace TravelApplication.Repository.Interface
{
    public interface IDestinationActivityRepository
    {
        Task<IEnumerable<DestinationActivity>> GetAllAsync();
        Task<DestinationActivity> GetByIdAsync(Guid destinationId, Guid activityId);
        Task AddAsync(DestinationActivity destinationActivity);
        Task RemoveAsync(Guid destinationId, Guid activityId);
        Task SaveChangesAsync();
    }
}
