using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;
using TravelApplication.Domain.Identity;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Booking : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage TravelPackage { get; set; }

        public string UserId { get; set; }
        public TravelApplicationUser User { get; set; }

        public decimal Price { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
