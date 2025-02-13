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
    public class Accommodation : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public AccommodationType? Type { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? Stars { get; set; }
        [Required]
        public decimal PricePerNight { get; set; }
        public List<string>? Amenities { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }

        public string? ImageUrl { get; set; }
    }
}
