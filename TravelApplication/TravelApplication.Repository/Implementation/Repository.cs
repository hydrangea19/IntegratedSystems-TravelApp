using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.Domain.MappingModels;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository.Interface;

namespace TravelApplication.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        private DbSet<TravelPackage> packagesEntities;
        private DbSet<Destination> destinationEntities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
            packagesEntities = context.Set<TravelPackage>();
            destinationEntities = context.Set<Destination>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Guid? id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public TravelPackage GetDetailsForTravelPackage(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id), "Travel package id must be provided.");
            }
            
            return packagesEntities
                 /*.Include(z => z.Destination)
                 .Include(z => z.PackageAccommodations).ThenInclude(pa => pa.Accommodation)
                 .Include(z => z.PackageActivities).ThenInclude(pa => pa.Activity)
                 .Include(z => z.PackageAttractions).ThenInclude(pa => pa.Attraction)
                 .Include(z => z.PackageTransports).ThenInclude(pt => pt.Transport)
                 .Include(z => z.PackageMeals).ThenInclude(pm => pm.Meal)*/
                 .SingleOrDefault(z => z.Id == id);
              
       }

        public TravelPackageDetailsDTO? GetTravelPackageDetails(Guid id)
        {
            var travelPackage = packagesEntities
            .AsNoTracking()
            .FirstOrDefault(tp => tp.Id == id);

            if (travelPackage == null)
            {
                return null; 
            }

            var dto = new TravelPackageDetailsDTO
            {
                Id = travelPackage.Id,
                Name = travelPackage.Name,
                Description = travelPackage.Description,
                DurationInDays = travelPackage.DurationInDays,
                TotalPrice = travelPackage.TotalPrice,
                IsCustomizable = travelPackage.IsCustomizable,
                ImageUrl = travelPackage.ImageUrl,
                Destination =  new DestinationDTO(),
                Accommodations = new List<AccommodationDTO>(),
                Meals = new List<MealDTO>(),
                Activities = new List<ActivityDTO>(),
                Attractions = new List<AttractionDTO>(),
                Transports = new List<TransportDTO>()
            };

            var destination = destinationEntities.SingleOrDefault(x => x.Id == travelPackage.DestinationId);

            dto.Destination = new DestinationDTO
            {
                Id = destination.Id,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                Climate = destination.Climate,
                ImageUrl = destination.ImageUrl
            };

            var accList = context.Set<TravelPackageAccommodation>()
                .AsNoTracking()
                .Where(pa => pa.TravelPackageId == id)
                .Include(pa => pa.Accommodation)
                .ToList();

            dto.Accommodations = accList
                .Where(pa => pa.Accommodation != null)
                .GroupBy(pa => pa.Accommodation.Id)
                .Select(g => new AccommodationDTO
            {
                Id = g.First().Accommodation.Id,
                Name = g.First().Accommodation.Name,
                PricePerNight = g.First().Accommodation.PricePerNight,
                ImageUrl = g.First().Accommodation.ImageUrl
             })
            .ToList();

            var mealList = context.Set<TravelPackageMeal>()
                .AsNoTracking()
                .Where(pm => pm.TravelPackageId == id)
                .Include(pm => pm.Meal)
                .ToList();

            dto.Meals = mealList
                .Where(pm => pm.Meal != null)
                .GroupBy(pm => pm.Meal.Id)
                .Select(m => new MealDTO
                {
                    Id = m.First().Meal.Id,
                    Name = m.First().Meal.Name,
                    Price = m.First().Meal.Price,
                    Description = m.First().Meal.Description,
                    ImageUrl = m.First().Meal.ImageUrl
                }).ToList();

            var activityList = context.Set<TravelPackageActivity>()
                .AsNoTracking()
                .Where(pa => pa.TravelPackageId == id)
                .Include(pa => pa.Activity)
                .ToList();

            dto.Activities = activityList
                .Where(pa => pa.Activity != null)
                .GroupBy(pa => pa.Activity.Id)
                .Select(p => new ActivityDTO
                {
                    Id = p.First().Activity.Id,
                    Name = p.First().Activity.Name,
                    Price = p.First().Activity.Price,
                    Description = p.First().Activity.Description,
                    ImageUrl = p.First().Activity.ImageUrl
                }).ToList();

            var attractionList = context.Set<TravelPackageAttraction>()
                .AsNoTracking()
                .Where(pa => pa.TravelPackageId == id)
                .Include(pa => pa.Attraction)
                .ToList();

            dto.Attractions = attractionList
                .Where(pa => pa.Attraction != null)
                .GroupBy(pa => pa.Attraction.Id)
                .Select(p => new AttractionDTO
                {
                    Id = p.First().Attraction.Id,
                    Name = p.First().Attraction.Name,
                    EntryFee = p.First().Attraction.EntryFee,
                    Description = p.First().Attraction.Description,
                    ImageUrl = p.First().Attraction.ImageUrl
                }).ToList();

            var transportList = context.Set<TravelPackageTransport>()
                .AsNoTracking()
                .Where(pt => pt.TravelPackageId == id)
                .Include(pt => pt.Transport)
                .ToList();

            dto.Transports = transportList
                .Where(pt => pt.Transport != null)
                .GroupBy(pt => pt.Transport.Id)
                .Select(p => new TransportDTO
                {
                    Id = p.First().Transport.Id,
                    Name = p.First().Transport.Type.ToString(), 
                    Price = p.First().Transport.Price,
                }).ToList();

            return dto;
        }


        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreatedAt = DateTime.Now;
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.UpdatedAt = DateTime.Now;
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
