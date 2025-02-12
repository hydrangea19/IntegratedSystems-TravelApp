using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelApplication.Domain.Domain;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class DestinationActivityService : IDestinationActivityService
    {
        private readonly IDestinationActivityRepository _destinationActivityRepository;

        public DestinationActivityService(IDestinationActivityRepository destinationActivityRepository)
        {
            _destinationActivityRepository = destinationActivityRepository;
        }

        public async Task<IEnumerable<DestinationActivity>> GetAllActivitiesForDestinations()
        {
            return await _destinationActivityRepository.GetAllAsync();
        }

        public async Task AddActivityToDestination(Guid destinationId, Guid activityId)
        {
            var destinationActivity = new DestinationActivity
            {
                DestinationId = destinationId,
                ActivityId = activityId
            };
            await _destinationActivityRepository.AddAsync(destinationActivity);
        }

        public async Task RemoveActivityFromDestination(Guid destinationId, Guid activityId)
        {
            await _destinationActivityRepository.RemoveAsync(destinationId, activityId);
        }
    }
}
