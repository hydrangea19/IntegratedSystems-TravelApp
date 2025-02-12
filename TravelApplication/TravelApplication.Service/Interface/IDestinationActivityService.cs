using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelApplication.Domain.Domain;

namespace TravelApplication.Service.Interface
{
    public interface IDestinationActivityService
    {
        Task<IEnumerable<DestinationActivity>> GetAllActivitiesForDestinations();
        Task AddActivityToDestination(Guid destinationId, Guid activityId);
        Task RemoveActivityFromDestination(Guid destinationId, Guid activityId);
    }
}
