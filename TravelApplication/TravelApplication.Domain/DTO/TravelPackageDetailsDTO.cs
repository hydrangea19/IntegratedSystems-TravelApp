using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class TravelPackageDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? DurationInDays { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsCustomizable { get; set; }
        public string? ImageUrl { get; set; }
        public DestinationDTO? Destination { get; set; }

        public List<AccommodationDTO> Accommodations { get; set; } = new List<AccommodationDTO>();
        public List<MealDTO> Meals { get; set; } = new List<MealDTO>();
        public List<ActivityDTO> Activities { get; set; } = new List<ActivityDTO>();
        public List<AttractionDTO> Attractions { get; set; } = new List<AttractionDTO>();
        public List<TransportDTO> Transports { get; set; } = new List<TransportDTO>();
    }
}
