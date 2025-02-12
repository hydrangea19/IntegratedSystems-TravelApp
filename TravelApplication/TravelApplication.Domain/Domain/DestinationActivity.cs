using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TravelApplication.Domain.Domain
{
    public class DestinationActivity
    {
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
