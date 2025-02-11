using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApplication.Domain.DTO
{
    public class AccommodationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } //NameOfHotelMaybe
        public string Type { get; set; } //Hotel.. Airbnb?
        public int price { get; set; }
        public Guid DestinationId { get; set; }
    }
}
