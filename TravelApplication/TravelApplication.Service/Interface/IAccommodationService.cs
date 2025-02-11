using TravelApplication.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TravelApplication.Service.Interfaces
{
    public interface IAccommodationService
    {
        Task<IEnumerable<AccommodationDTO>> GetAllAsync();
        Task<AccommodationDTO?> GetByIdAsync(int id);
        Task AddAsync(AccommodationDTO accommodation);
        Task UpdateAsync(AccommodationDTO accommodation);
        Task DeleteAsync(int id);
    }
}
