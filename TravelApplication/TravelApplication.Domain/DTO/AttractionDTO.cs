using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class AttractionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal EntryFee { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
