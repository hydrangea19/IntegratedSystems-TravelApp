using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;

namespace TravelApplication.Domain.DTO
{
    public class DestinationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Description { get; set; }
        public ClimateType? Climate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
