using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class TravelPackageOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? DurationInDays { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsCustomizable { get; set; }
        public string? ImageUrl { get; set; }
        public DestinationOutputDTO? Destination { get; set; }
        public IEnumerable<Guid>? AccommodationIds { get; set; }
        public IEnumerable<Guid>? MealIds { get; set; }
        public IEnumerable<Guid>? ActivityIds { get; set; }
        public IEnumerable<Guid>? AttractionIds { get; set; }
        public IEnumerable<Guid>? TransportIds { get; set; }
    }
}
