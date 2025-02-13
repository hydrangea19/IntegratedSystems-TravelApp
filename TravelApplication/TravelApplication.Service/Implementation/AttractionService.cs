using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class AttractionService : IAttractionService
    {
        private readonly IRepository<Attraction> _attractionRepository;

        public AttractionService(IRepository<Attraction> attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }
        public void AddAttraction(Attraction attraction)
        {
            if (attraction == null)
            {
                throw new ArgumentException(nameof(attraction), "Attraction data cannot be null.");
            }
            _attractionRepository.Insert(attraction);
            
        }

        public void DeleteAttraction(Guid id)
        {
            Attraction attraction = _attractionRepository.Get(id);
            if (attraction != null) {
                _attractionRepository.Delete(attraction);
            }
        }

        public List<Attraction> GetAllAttractions()
        {
            return _attractionRepository.GetAll().ToList();
        }

        public Attraction GetAttractionById(Guid id)
        {
            return _attractionRepository.Get(id);
        }

        public void UpdateAttraction(Attraction attraction)
        {
            _attractionRepository.Update(attraction);
        }
    }
}
