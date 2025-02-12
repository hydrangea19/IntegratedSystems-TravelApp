using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelApplication.Domain.Domain;

namespace TravelApplication.Service.Interface
{
    public interface IDestinationTransportService
    {
        Task<IEnumerable<DestinationTransport>> GetAllTransportsForDestinations();
        Task AddTransportToDestination(Guid destinationId, Guid transportId);
        Task RemoveTransportFromDestination(Guid destinationId, Guid transportId);
    }
}
