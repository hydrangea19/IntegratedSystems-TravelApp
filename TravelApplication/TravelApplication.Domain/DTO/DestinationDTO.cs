using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class DestinationDTO
    {
        public Guid TravelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; } //TripPlan
        public List<AccommodationDTO>Accommodations { get; set; }
    }
}
