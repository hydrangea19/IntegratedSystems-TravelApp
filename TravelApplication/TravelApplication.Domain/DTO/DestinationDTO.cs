using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace TravelApplication.Domain.DTO
{
    public class DestinationDTO
    {
        public Guid TravelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public List<AccommodationDTO> Accommodations { get; set; } = new();
        public List<ActivityDTO> Activities { get; set; } = new();
        public List<TransportDTO> Transports { get; set; } = new();

        public List<Guid> SelectedActivityIds { get; set; } = new();
        public List<Guid> SelectedTransportIds { get; set; } = new();
    }
}