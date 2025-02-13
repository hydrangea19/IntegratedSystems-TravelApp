using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface IAccommodationService
    {
        List<Accommodation> GetAllAccommodations();
        Accommodation GetAccommodationById(Guid id);
        void AddAccommodation(Accommodation accommodation);
        void UpdateAccommodation(Accommodation accommodation);
        void DeleteAccommodation(Guid id);
    }
}
