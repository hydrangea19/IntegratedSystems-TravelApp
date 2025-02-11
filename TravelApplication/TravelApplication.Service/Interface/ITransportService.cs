using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Service.Interface
{
    public interface ITransportService
    {
        Task<IEnumerable<TransportDTO>> GetAllTransportsAsync();
        Task<TransportDTO> GetTransportByIdAsync(int id);
        Task AddTransportAsync(TransportDTO transportDto);
        Task UpdateTransportAsync(TransportDTO transportDto);
        Task DeleteTransportAsync(int id);
    }
}
