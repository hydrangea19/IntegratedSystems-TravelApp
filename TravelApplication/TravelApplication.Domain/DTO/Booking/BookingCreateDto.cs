using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO.Booking
{
    public class BookingCreateDto
    {
        [Required]
        public Guid TravelPackageId { get; set; }
    }
}
