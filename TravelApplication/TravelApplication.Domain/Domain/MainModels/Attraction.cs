using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Attraction : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        [Required]
        public decimal EntryFee { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }

        public string? ImageUrl { get; set; }

        public virtual IEnumerable<TravelPackageAttraction>? PackageAttractions { get; set; }
    }
}
