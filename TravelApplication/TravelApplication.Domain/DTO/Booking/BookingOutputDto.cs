using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;

namespace TravelApplication.Domain.DTO.Booking
{
    public class BookingOutputDto
    {
        public Guid Id { get; set; }
        public Guid TravelPackageId { get; set; }
        public string TravelPackageName { get; set; }
        public decimal Cost { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
