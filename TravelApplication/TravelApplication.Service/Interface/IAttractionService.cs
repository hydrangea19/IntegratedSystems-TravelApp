using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface IAttractionService
    {
        List<Attraction> GetAllAttractions();
        Attraction GetAttractionById(Guid id);
        void AddAttraction(Attraction attraction);
        void UpdateAttraction(Attraction attraction);
        void DeleteAttraction(Guid id);
    }
}
