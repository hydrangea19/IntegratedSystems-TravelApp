using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;

namespace TravelApplication.Repository.Interface
{
    public interface ITransportRepository
    {
        Task<IEnumerable<Transport>> GetAllAsync();
        Task<Transport> GetByIdAsync(int id);
        Task AddAsync(Transport transport);
        Task UpdateAsync(Transport transport);
        Task<bool> DeleteAsync(int id);
    }
}
