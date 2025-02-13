using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Service.Interface
{
    public interface ITravelPackageService
    {
        List<TravelPackage> GetAllTravelPackages();
        TravelPackage GetTravelPackageById(Guid id);
        TravelPackage AddTravelPackage(TravelPackageDTO travelPackage);
        void UpdateTravelPackage(TravelPackage travelPackage);
        void DeleteTravelPackage(Guid id);

        TravelPackageDetailsDTO? GetTravelPackageDetails(Guid id);
    }
}
