using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository<Destination> _destinationRepository;

        public DestinationService(IRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }
        public void AddDestination(Destination destination)
        {
            if (destination == null)
            {
                throw new ArgumentException(nameof(destination), "Destination data cannot be null.");
            }
            _destinationRepository.Insert(destination);
        }

        public void DeleteDestination(Guid id)
        {
            Destination destination = _destinationRepository.Get(id);
            if (destination != null)
            {
                _destinationRepository.Delete(destination);
            }
        }

        public List<Destination> GetAllDestinations()
        {
            return _destinationRepository.GetAll().ToList();
        }

        public Destination GetDestinationById(Guid id)
        {
            return _destinationRepository.Get(id);
        }

        public void UpdateDestination(Destination destination)
        {
            _destinationRepository.Update(destination);
        }
    }
}
