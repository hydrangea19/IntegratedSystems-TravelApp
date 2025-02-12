using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using System;

namespace TravelApplication.Domain.Domain
{
    public class DestinationTransport
    {
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }

        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
