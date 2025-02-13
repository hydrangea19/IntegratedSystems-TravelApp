using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Domain.Domain.MappingModels
{
    public class TravelPackageAttraction : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        public Guid AttractionId { get; set; }
        public Attraction? Attraction { get; set; }
    }
}
