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
    public class AccommodationService : IAccommodationService
    {
        private readonly IRepository<Accommodation> _accommodationRepository;

        public AccommodationService(IRepository<Accommodation> accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            if(accommodation == null)
            {
                throw new ArgumentException(nameof(accommodation), "Accommodation data cannot be null.");
            }
            _accommodationRepository.Insert(accommodation);
        }

        public void DeleteAccommodation(Guid id)
        {
            Accommodation accommodation = _accommodationRepository.Get(id);
            if (accommodation != null)
            {
                _accommodationRepository.Delete(accommodation);
            }
        }

        public Accommodation GetAccommodationById(Guid id)
        {
            return _accommodationRepository.Get(id);
        }

        public List<Accommodation> GetAllAccommodations()
        {
            return _accommodationRepository.GetAll().ToList();
        }

        public void UpdateAccommodation(Accommodation accommodation)
        {
            _accommodationRepository.Update(accommodation);
        }
    }
}
