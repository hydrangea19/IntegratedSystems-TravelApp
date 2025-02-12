using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace TravelApplication.Domain.Domain
{
    public class Activity
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Cost { get; set; }
        public int DurationHours { get; set; }

        public ICollection<DestinationActivity> DestinationActivities { get; set; } = new List<DestinationActivity>();
    }
}