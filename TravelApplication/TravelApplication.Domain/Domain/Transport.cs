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
    public class Transport
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string DeparturePoint { get; set; } 
        public string ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal CostPerPassenger { get; set; }

        public ICollection<DestinationTransport> DestinationTransports { get; set; } = new List<DestinationTransport>();
    }
}
