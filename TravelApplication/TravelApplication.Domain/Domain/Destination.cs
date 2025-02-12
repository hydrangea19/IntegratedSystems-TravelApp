using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;


namespace TravelApplication.Domain.Domain
{
    public class Destination
    {
        public Guid TravelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty; 
        public decimal Price { get; set; } 

        public List<Accommodation> Accommodations { get; set; } = new();

        public List<DestinationTransport> DestinationTransports { get; set; } = new();
        public List<DestinationActivity> DestinationActivities { get; set; } = new();
    }
}