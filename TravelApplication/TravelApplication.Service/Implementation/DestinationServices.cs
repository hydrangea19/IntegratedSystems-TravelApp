using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class DestinationServices : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationServices(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DestinationDTO>> GetAllAsync()
        {
            var destinations = await _repository.GetAllAsync();
            return destinations.Select(d => new DestinationDTO
            {
                TravelId = d.TravelId,
                Name = d.Name,
                Country = d.Country,
                Description = d.Description
            });
        }

        public async Task<DestinationDTO?> GetByIdAsync(Guid travelId)
        {
            var destination = await _repository.GetByIdAsync(travelId);
            return destination == null ? null : new DestinationDTO
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description
            };
        }

        public async Task AddAsync(DestinationDTO destination)
        {
            await _repository.AddAsync(new Destination
            {
                TravelId = Guid.NewGuid(),
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description
            });
        }

        public async Task UpdateAsync(DestinationDTO destination)
        {
            await _repository.UpdateAsync(new Destination
            {
                TravelId = destination.TravelId,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description
            });
        }

        public async Task DeleteAsync(Guid travelId)
        {
            await _repository.DeleteAsync(travelId);
        }
    }
}
