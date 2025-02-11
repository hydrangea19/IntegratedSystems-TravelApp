using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;
using TravelApplication.Service.Interfaces;

namespace TravelApplication.Service.Implementation
{
    public class AccommodationServices : IAccommodationService
    {
        private readonly IAccommodationRepository _repository;

        public AccommodationServices(IAccommodationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AccommodationDTO>> GetAllAsync()
        {
            var accommodations = await _repository.GetAllAsync();
            return accommodations.Select(a => new AccommodationDTO
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type,
                price = a.Price,
                DestinationId = a.DestinationId
            });
        }

        public async Task<AccommodationDTO?> GetByIdAsync(int id)
        {
            var accommodation = await _repository.GetByIdAsync(id);
            return accommodation == null ? null : new AccommodationDTO
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Type = accommodation.Type,
                price = accommodation.Price,
                DestinationId = accommodation.DestinationId
            };
        }

        public async Task AddAsync(AccommodationDTO accommodation)
        {
            await _repository.AddAsync(new Accommodation
            {
                Name = accommodation.Name,
                Type = accommodation.Type,
                Price = accommodation.price,
                DestinationId = accommodation.DestinationId
            });
        }

        public async Task UpdateAsync(AccommodationDTO accommodation)
        {
            await _repository.UpdateAsync(new Accommodation
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Type = accommodation.Type,
                Price = accommodation.price,
                DestinationId = accommodation.DestinationId
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
