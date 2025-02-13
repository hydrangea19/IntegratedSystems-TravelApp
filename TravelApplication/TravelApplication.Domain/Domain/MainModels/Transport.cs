using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Transport : BaseEntity
    {
        public TransportType? Type { get; set; }
        public string? Provider { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }

        public virtual IEnumerable<TravelPackageTransport>? PackageTransports { get; set; }
    }

}
