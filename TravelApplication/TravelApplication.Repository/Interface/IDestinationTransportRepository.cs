using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelApplication.Domain.Domain;

namespace TravelApplication.Repository.Interface
{
    public interface IDestinationTransportRepository
    {
        Task<IEnumerable<DestinationTransport>> GetAllAsync();
        Task<DestinationTransport> GetByIdAsync(Guid destinationId, Guid transportId);
        Task AddAsync(DestinationTransport destinationTransport);
        Task RemoveAsync(Guid destinationId, Guid transportId);
        Task SaveChangesAsync();
    }
}

