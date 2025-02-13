using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelApplication.Domain.DTO.Booking;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                var result = await _bookingService.CreateBookingAsync(dto, userId);
                return CreatedAtAction(nameof(GetBookingsForUser), new { }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsForUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var bookings = await _bookingService.GetBookingsForUserAsync(userId);
            return Ok(bookings);
        }

        [HttpPost("confirm/{bookingId}")]
        public async Task<IActionResult> ConfirmBooking(Guid bookingId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                var itinerary = await _bookingService.ConfirmBookingAsync(bookingId, userId);
                return Ok(itinerary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("itineraries")]
        public async Task<IActionResult> GetItinerariesForUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var itineraries = await _bookingService.GetItinerariesForUserAsync(userId);
            return Ok(itineraries);
        }

        [HttpGet("itinerary/{id}")]
        public async Task<IActionResult> GetItineraryById(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                var itineraryDto = await _bookingService.GetItineraryByIdAsync(id, userId);
                return Ok(itineraryDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("itinerary/exportpdf/{id}")]
        [Authorize]
        public async Task<IActionResult> ExportItineraryAsPdf(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
              
                var itineraryDto = await _bookingService.GetItineraryByIdAsync(id, userId);
                if (itineraryDto == null)
                    return NotFound("Itinerary not found.");

                byte[] pdfBytes = _bookingService.GenerateItineraryPdf(itineraryDto);

                Console.WriteLine($"Exporting itinerary {id} for user {userId}");


                return File(pdfBytes, "application/pdf", $"itinerary_{id}.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
