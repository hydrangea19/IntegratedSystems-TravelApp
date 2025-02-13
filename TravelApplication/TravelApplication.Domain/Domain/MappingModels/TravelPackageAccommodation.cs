using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Domain.Domain.MappingModels
{
    public class TravelPackageAccommodation : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        public Guid AccommodationId { get; set; }
        public Accommodation? Accommodation { get; set; }

    }
}
