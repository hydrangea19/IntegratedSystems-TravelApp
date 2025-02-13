using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class TravelPackage : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? DestinationId { get; set; }
        public Destination? Destination { get; set; }
        public int? DurationInDays { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public bool? IsCustomizable { get; set; }
        public string? ImageUrl { get; set; }

        public virtual IEnumerable<TravelPackageAccommodation>? PackageAccommodations { get; set; }
        public virtual IEnumerable<TravelPackageActivity>? PackageActivities { get; set; }

        public virtual IEnumerable<TravelPackageAttraction>? PackageAttractions { get; set; }

        public virtual IEnumerable<TravelPackageTransport>? PackageTransports { get; set; }

        public virtual IEnumerable<TravelPackageMeal>? PackageMeals { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
