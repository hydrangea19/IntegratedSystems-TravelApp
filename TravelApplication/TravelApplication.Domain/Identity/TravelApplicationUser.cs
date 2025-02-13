using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Domain.Identity
{
    public class TravelApplicationUser : IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? dateOfBirth { get; set; }

        public string? profilePictureUrl { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
