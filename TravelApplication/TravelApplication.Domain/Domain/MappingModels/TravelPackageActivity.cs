using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Domain.Domain.MappingModels
{
    public class TravelPackageActivity : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }
        public Guid ActivityId { get; set; }
        public Activity? Activity { get; set; }
    }
}
