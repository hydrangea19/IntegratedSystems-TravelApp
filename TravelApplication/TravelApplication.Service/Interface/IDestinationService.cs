using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Service.Interface
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationDTO>> GetAllAsync();
        Task<DestinationDTO?> GetByIdAsync(Guid travelId);
        Task AddAsync(DestinationDTO destination);
        Task UpdateAsync(DestinationDTO destination);
        Task DeleteAsync(Guid travelId);
    }
}
