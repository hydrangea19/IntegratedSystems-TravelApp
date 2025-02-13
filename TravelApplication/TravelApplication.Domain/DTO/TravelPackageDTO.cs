using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.DTO
{
    public class TravelPackageDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string DestinationId { get; set; }  
        public int? DurationInDays { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public bool? IsCustomizable { get; set; }
        public string? ImageUrl { get; set; }

        public IEnumerable<TravelPackageAccommodation>? PackageAccommodations { get; set; }
        public IEnumerable<TravelPackageActivity>? PackageActivities { get; set; }
        public IEnumerable<TravelPackageAttraction>? PackageAttractions { get; set; }
        public IEnumerable<TravelPackageTransport>? PackageTransports { get; set; }
        public IEnumerable<TravelPackageMeal>? PackageMeals { get; set; }
    }
}
