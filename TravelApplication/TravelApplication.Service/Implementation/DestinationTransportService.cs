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
    public class DestinationTransportService : IDestinationTransportService
    {
        private readonly IDestinationTransportRepository _destinationTransportRepository;

        public DestinationTransportService(IDestinationTransportRepository destinationTransportRepository)
        {
            _destinationTransportRepository = destinationTransportRepository;
        }

        public async Task<IEnumerable<DestinationTransport>> GetAllTransportsForDestinations()
        {
            return await _destinationTransportRepository.GetAllAsync();
        }

        public async Task AddTransportToDestination(Guid destinationId, Guid transportId)
        {
            var destinationTransport = new DestinationTransport
            {
                DestinationId = destinationId,
                TransportId = transportId
            };
            await _destinationTransportRepository.AddAsync(destinationTransport);
        }

        public async Task RemoveTransportFromDestination(Guid destinationId, Guid transportId)
        {
            await _destinationTransportRepository.RemoveAsync(destinationId, transportId);
        }
    }
}
