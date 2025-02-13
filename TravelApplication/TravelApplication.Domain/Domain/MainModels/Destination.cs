using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Destination : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public ClimateType? Climate { get; set; }
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public IEnumerable<TravelPackage>? TravelPackages { get; set; }
    }
}
