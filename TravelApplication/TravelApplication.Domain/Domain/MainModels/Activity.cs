using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Activity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        [Required]
        public decimal Price { get; set; }
        public TimeSpan? Duration { get; set; }
        public ActivityType? ActivityType { get; set; }

        public string? ImageUrl { get; set; }

        public virtual IEnumerable<TravelPackageActivity>? PackageActivities { get; set; }
    }
}
