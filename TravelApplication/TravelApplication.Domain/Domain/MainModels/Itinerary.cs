using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Itinerary : BaseEntity
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }

        public string Details { get; set; }
    }
}
