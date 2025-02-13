using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.Domain.MappingModels;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class TravelPackageService : ITravelPackageService
    {
        private readonly IRepository<TravelPackage> _travelPackageRepository;
        private readonly IRepository<Accommodation> _accommodationRepository;
        private readonly IRepository<TravelPackageAccommodation> _travelPackageAccommodationRepository;
        private readonly IRepository<Activity> _activityRepository;
        private readonly IRepository<TravelPackageActivity> _travelPackageActivityRepository;
        private readonly IRepository<Meal> _mealRepository;
        private readonly IRepository<TravelPackageMeal> _travelPackageMealRepository;
        private readonly IRepository<Attraction> _attractionRepository;
        private readonly IRepository<TravelPackageAttraction> _travelPackageAttractionRepository;
        private readonly IRepository<Transport> _transportRepository;
        private readonly IRepository<TravelPackageTransport> _travelPackageTransportRepository;
        private readonly IRepository<Destination> _destinationRepository;
        public TravelPackageService(IRepository<TravelPackage> travelPackageRepository,
            IRepository<Accommodation> accommodationRepository,
            IRepository<TravelPackageAccommodation> travelPackageAccommodationRepository,
            IRepository<Activity> activityRepository,
            IRepository<TravelPackageActivity> travelPackageActivityRepository,
            IRepository<Meal> mealRepository,
            IRepository<TravelPackageMeal> travelPackageMealRepository,
            IRepository<Attraction> attractionRepository,
            IRepository<TravelPackageAttraction> travelPackageAttractionRepository,
            IRepository<Transport> transportRepository,
            IRepository<TravelPackageTransport> travelPackageTransportRepository,
            IRepository<Destination> destinationRepository)
        {
            _travelPackageRepository = travelPackageRepository;
            _accommodationRepository = accommodationRepository;
            _travelPackageAccommodationRepository = travelPackageAccommodationRepository;
            _activityRepository = activityRepository;
            _travelPackageActivityRepository = travelPackageActivityRepository;
            _mealRepository = mealRepository;
            _travelPackageMealRepository = travelPackageMealRepository;
            _attractionRepository = attractionRepository;
            _travelPackageAttractionRepository = travelPackageAttractionRepository;
            _transportRepository = transportRepository;
            _travelPackageTransportRepository = travelPackageTransportRepository;
            _destinationRepository = destinationRepository;
        }

        public TravelPackage AddTravelPackage(TravelPackageDTO travelPackageDto)
        {
            if (travelPackageDto == null)
            {
                throw new ArgumentException(nameof(travelPackageDto), "Travel Package data cannot be null.");
            }

            var travelPackage = new TravelPackage
            {
                Name = travelPackageDto.Name,
                Description = travelPackageDto.Description,
                DurationInDays = travelPackageDto.DurationInDays,
                IsCustomizable = travelPackageDto.IsCustomizable,
                ImageUrl = travelPackageDto.ImageUrl,
                PackageAccommodations = travelPackageDto.PackageAccommodations,
                PackageActivities = travelPackageDto.PackageActivities,
                PackageAttractions = travelPackageDto.PackageAttractions,
                PackageTransports = travelPackageDto.PackageTransports,
                PackageMeals = travelPackageDto.PackageMeals
            };

            if (!Guid.TryParse(travelPackageDto.DestinationId, out Guid destId))
            {
                throw new Exception("Invalid Destination ID format.");
            }

            var destination = _destinationRepository.Get(destId);
            if (destination == null)
            {
                throw new Exception("Selected destination does not exist.");
            }
            travelPackage.Destination = destination;

            travelPackage.TotalPrice = ComputeTotalPrice(travelPackage);

            _travelPackageRepository.Insert(travelPackage);

            if (travelPackage.PackageAccommodations != null)
            {
                foreach (var packageAccommodation in travelPackage.PackageAccommodations)
                {
                    
                    packageAccommodation.Id = Guid.NewGuid();
                    

                    var existingAccommodation = _accommodationRepository.Get(packageAccommodation.AccommodationId);
                    if (existingAccommodation != null)
                    {
                        packageAccommodation.TravelPackageId = travelPackage.Id;
                        packageAccommodation.AccommodationId = existingAccommodation.Id;
                        _travelPackageAccommodationRepository.Insert(packageAccommodation);
                    }
                }
            }

            if (travelPackage.PackageActivities != null)
            {
                foreach (var packageActivity in travelPackage.PackageActivities)
                {
                    
                     packageActivity.Id = Guid.NewGuid();
                    
                    var existingActivity = _activityRepository.Get(packageActivity.ActivityId);
                    if (existingActivity != null)
                    {
                        packageActivity.TravelPackageId = travelPackage.Id;
                        packageActivity.ActivityId = existingActivity.Id;
                        _travelPackageActivityRepository.Insert(packageActivity);
                    }
                }
            }

            if (travelPackage.PackageAttractions != null)
            {
                foreach (var packageAttraction in travelPackage.PackageAttractions)
                {
                    
                     packageAttraction.Id = Guid.NewGuid();
                    
                    var existingAttraction = _attractionRepository.Get(packageAttraction.AttractionId);
                    if (existingAttraction != null)
                    {
                        packageAttraction.TravelPackageId = travelPackage.Id;
                        packageAttraction.AttractionId = existingAttraction.Id;
                        _travelPackageAttractionRepository.Insert(packageAttraction);
                    }
                }
            }

            if (travelPackage.PackageTransports != null)
            {
                foreach (var packageTransport in travelPackage.PackageTransports)
                {
                    
                     packageTransport.Id = Guid.NewGuid();
                    
                    var existingTransport = _transportRepository.Get(packageTransport.TransportId);
                    if (existingTransport != null)
                    {
                        packageTransport.TravelPackageId = travelPackage.Id;
                        packageTransport.TransportId = existingTransport.Id;
                        _travelPackageTransportRepository.Insert(packageTransport);
                    }
                }
            }

            if (travelPackage.PackageMeals != null)
            {
                foreach (var packageMeal in travelPackage.PackageMeals)
                {
                  
                     packageMeal.Id = Guid.NewGuid();
                    
                    var existingMeal = _mealRepository.Get(packageMeal.MealId);
                    if (existingMeal != null)
                    {
                        packageMeal.TravelPackageId = travelPackage.Id;
                        packageMeal.MealId = existingMeal.Id;
                        _travelPackageMealRepository.Insert(packageMeal);
                    }
                }
            }
            return travelPackage;
        }

        public void DeleteTravelPackage(Guid id)
        {
            TravelPackage travelPackage = _travelPackageRepository.Get(id);
            if (travelPackage != null)
            {
                _travelPackageRepository.Delete(travelPackage);
            }
        }

        public List<TravelPackage> GetAllTravelPackages()
        {
            return _travelPackageRepository.GetAll().ToList();
        }

        public TravelPackage GetTravelPackageById(Guid id)
        {
            return _travelPackageRepository.GetDetailsForTravelPackage(id);
        }

        public void UpdateTravelPackage(TravelPackage travelPackage)
        {
            if (travelPackage.Destination != null)
            { 
                var existingDestination = _destinationRepository.Get(travelPackage.Destination.Id);
                if (existingDestination != null)
                {
                    existingDestination.Name = travelPackage.Destination.Name;  
                    _destinationRepository.Update(existingDestination);

                    travelPackage.Destination = existingDestination;
                }
                else
                {
                    _destinationRepository.Insert(travelPackage.Destination);
                }
            }

            if (travelPackage.PackageAccommodations != null)
            {
                var existingAccommodations = _travelPackageAccommodationRepository.GetAll()
                    .Where(pa => pa.TravelPackageId == travelPackage.Id)
                    .ToList();
                foreach (var existingAccommodation in existingAccommodations)
                {
                    _travelPackageAccommodationRepository.Delete(existingAccommodation);
                }
            }

            foreach (var packageAccommodation in travelPackage.PackageAccommodations)
            {
                var existingAccommodation = _accommodationRepository.Get(packageAccommodation.AccommodationId);
                if (existingAccommodation != null)
                {
                    packageAccommodation.TravelPackageId = travelPackage.Id;
                    packageAccommodation.AccommodationId = existingAccommodation.Id;
                    _travelPackageAccommodationRepository.Insert(packageAccommodation);
                }
            }

            if (travelPackage.PackageActivities != null)
            {
                var existingActivities = _travelPackageActivityRepository.GetAll()
                    .Where(pa => pa.TravelPackageId == travelPackage.Id)
                    .ToList();
                foreach (var existingActivity in existingActivities)
                {
                    _travelPackageActivityRepository.Delete(existingActivity);
                }

                foreach (var packageActivity in travelPackage.PackageActivities)
                {
                    var existingActivity = _activityRepository.Get(packageActivity.ActivityId);
                    if (existingActivity != null)
                    {
                        packageActivity.TravelPackageId = travelPackage.Id;
                        packageActivity.ActivityId = existingActivity.Id;
                        _travelPackageActivityRepository.Insert(packageActivity);
                    }
                }
            }
            if (travelPackage.PackageTransports != null)
            {
                var existingTransports = _travelPackageTransportRepository.GetAll()
                    .Where(pa => pa.TravelPackageId == travelPackage.Id)
                    .ToList();
                foreach (var existingTransport in existingTransports)
                {
                    _travelPackageTransportRepository.Delete(existingTransport);
                }

                foreach (var packageTransport in travelPackage.PackageTransports)
                {
                    var existingTransport = _transportRepository.Get(packageTransport.TransportId);
                    if (existingTransport != null)
                    {
                        packageTransport.TravelPackageId = travelPackage.Id;
                        packageTransport.TransportId = existingTransport.Id;
                        _travelPackageTransportRepository.Insert(packageTransport);
                    }
                }
            }
            if (travelPackage.PackageMeals != null)
            {
                var existingMeals = _travelPackageMealRepository.GetAll()
                    .Where(pa => pa.TravelPackageId == travelPackage.Id)
                    .ToList();
                foreach (var existingMeal in existingMeals)
                {
                    _travelPackageMealRepository.Delete(existingMeal);
                }

                foreach (var packageMeal in travelPackage.PackageMeals)
                {
                    var existingMeal = _mealRepository.Get(packageMeal.MealId);
                    if (existingMeal != null)
                    {
                        packageMeal.TravelPackageId = travelPackage.Id;
                        packageMeal.MealId = existingMeal.Id;
                        _travelPackageMealRepository.Insert(packageMeal);
                    }
                }
                travelPackage.TotalPrice = ComputeTotalPrice(travelPackage);

                _travelPackageRepository.Update(travelPackage);
            }
        }
        private decimal ComputeTotalPrice(TravelPackage travelPackage)
        {
            decimal total = 0m;

            if (travelPackage.PackageAccommodations != null)
            {
                foreach (var packageAccommodation in travelPackage.PackageAccommodations)
                {
                    var accommodation = _accommodationRepository.Get(packageAccommodation.AccommodationId);
                    if (accommodation != null)
                    {
                        total += accommodation.PricePerNight;
                    }
                }
            }

            if (travelPackage.PackageMeals != null)
            {
                foreach (var packageMeal in travelPackage.PackageMeals)
                {
                    var meal = _mealRepository.Get(packageMeal.MealId);
                    if (meal != null)
                    {
                        total += meal.Price;
                    }
                }
            }

            if (travelPackage.PackageActivities != null)
            {
                foreach (var packageActivity in travelPackage.PackageActivities)
                {
                    var activity = _activityRepository.Get(packageActivity.ActivityId);
                    if (activity != null)
                    {
                        total += activity.Price;
                    }
                }
            }

            if (travelPackage.PackageAttractions != null)
            {
                foreach (var packageAttraction in travelPackage.PackageAttractions)
                {
                    var attraction = _attractionRepository.Get(packageAttraction.AttractionId);
                    if (attraction != null)
                    {
                        total += attraction.EntryFee;
                    }
                }
            }

            if (travelPackage.PackageTransports != null)
            {
                foreach (var packageTransport in travelPackage.PackageTransports)
                {
                    var transport = _transportRepository.Get(packageTransport.TransportId);
                    if (transport != null)
                    {
                        total += transport.Price;
                    }
                }
            }

            int days = (travelPackage.DurationInDays.HasValue && travelPackage.DurationInDays.Value > 0)
                ? travelPackage.DurationInDays.Value
                : 1;

            return total * days;
        }
        public TravelPackageDetailsDTO? GetTravelPackageDetails(Guid id)
        {
            return _travelPackageRepository.GetTravelPackageDetails(id);
        }
    }
}
