using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class ItineraryOutputDto
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public string Details { get; set; }
    }
}
