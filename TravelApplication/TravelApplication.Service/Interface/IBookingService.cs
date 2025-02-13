using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;
using TravelApplication.Domain.DTO.Booking;

namespace TravelApplication.Service.Interface
{
    public interface IBookingService
    {
        Task<BookingOutputDto> CreateBookingAsync(BookingCreateDto dto, string userId);
        Task<IEnumerable<BookingOutputDto>> GetBookingsForUserAsync(string userId);
        Task<ItineraryOutputDto> ConfirmBookingAsync(Guid bookingId, string userId);
        Task<IEnumerable<ItineraryOutputDto>> GetItinerariesForUserAsync(string userId);
        Task<ItineraryOutputDto> GetItineraryByIdAsync(Guid itineraryId, string userId);
        byte[] GenerateItineraryPdf(ItineraryOutputDto itinerary);
    }
}
