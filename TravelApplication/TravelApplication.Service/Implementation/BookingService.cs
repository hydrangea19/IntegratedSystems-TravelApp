using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.DTO;
using TravelApplication.Domain.DTO.Booking;
using TravelApplication.Repository;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;

namespace TravelApplication.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookingOutputDto> CreateBookingAsync(BookingCreateDto dto, string userId)
        {
            var travelPackage = await _context.TravelPackages
            .AsNoTracking()
            .FirstOrDefaultAsync(tp => tp.Id == dto.TravelPackageId);

            if (travelPackage == null)
                throw new Exception("Travel package not found.");

       
            var booking = new Booking
            {
                TravelPackageId = dto.TravelPackageId,
                UserId = userId,
                Price = travelPackage.TotalPrice,
                Status = BookingStatus.Pending,
                BookingDate = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            var outputDto = new BookingOutputDto
            {
                Id = booking.Id,
                TravelPackageId = booking.TravelPackageId,
                TravelPackageName = travelPackage.Name,
                Cost = booking.Price,
                Status = booking.Status,
                BookingDate = booking.BookingDate
            };

            return outputDto;
        }

        public async Task<IEnumerable<BookingOutputDto>> GetBookingsForUserAsync(string userId)
        {
            var bookings = await _context.Bookings
            .Where(b => b.UserId == userId)
            .Include(b => b.TravelPackage)
            .ToListAsync();

            return bookings.Select(b => new BookingOutputDto
            {
                Id = b.Id,
                TravelPackageId = b.TravelPackageId,
                TravelPackageName = b.TravelPackage != null ? b.TravelPackage.Name : "Unknown",
                Cost = b.Price,
                Status = b.Status,
                BookingDate = b.BookingDate
            });
        }
        public async Task<ItineraryOutputDto> ConfirmBookingAsync(Guid bookingId, string userId)
        {
            var booking = await _context.Bookings
                .Include(b => b.TravelPackage)
                    .ThenInclude(tp => tp.PackageAccommodations)
                        .ThenInclude(pa => pa.Accommodation)
                .Include(b => b.TravelPackage)
                    .ThenInclude(tp => tp.PackageMeals)
                        .ThenInclude(pm => pm.Meal)
                .Include(b => b.TravelPackage)
                    .ThenInclude(tp => tp.PackageActivities)
                        .ThenInclude(pa => pa.Activity)
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.UserId == userId);

            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }

            if (booking.Status == BookingStatus.Confirmed)
            {
                throw new Exception("Booking is already confirmed.");
            }

            booking.Status = BookingStatus.Confirmed;
            await _context.SaveChangesAsync();

            string itineraryDetails = GenerateItinerary(booking.TravelPackage);

            var itinerary = new Itinerary
            {
                BookingId = booking.Id,
                Details = itineraryDetails
            };

            _context.Itineraries.Add(itinerary);
            await _context.SaveChangesAsync();

            return new ItineraryOutputDto
            {
                Id = itinerary.Id,
                BookingId = itinerary.BookingId,
                Details = itinerary.Details
            };
        }

        private string GenerateItinerary(TravelPackage travelPackage)
        {
            int days = travelPackage.DurationInDays ?? 1;
            var sb = new StringBuilder();
            sb.AppendLine("Itinerary Details:");

            var accommodations = travelPackage.PackageAccommodations?
                                        .Select(pa => pa.Accommodation)
                                        .Where(a => a != null)
                                        .ToList() ?? new List<Accommodation>();
            var meals = travelPackage.PackageMeals?
                            .Select(pm => pm.Meal)
                            .Where(m => m != null)
                            .ToList() ?? new List<Meal>();
            var activities = travelPackage.PackageActivities?
                                .Select(pa => pa.Activity)
                                .Where(a => a != null)
                                .ToList() ?? new List<Activity>();

            for (int day = 1; day <= days; day++)
            {
                sb.AppendLine($"Day {day}:");

                if (accommodations.Count > 0)
                    sb.AppendLine($"  Accommodation: {accommodations[(day - 1) % accommodations.Count].Name}");
                else
                    sb.AppendLine("  Accommodation: N/A");

                if (meals.Count > 0)
                    sb.AppendLine($"  Meal: {meals[(day - 1) % meals.Count].Name}");
                else
                    sb.AppendLine("  Meal: N/A");

                if (activities.Count > 0)
                    sb.AppendLine($"  Activity: {activities[(day - 1) % activities.Count].Name}");
                else
                    sb.AppendLine("  Activity: N/A");

                sb.AppendLine(); 
            }

            return sb.ToString();
        }

        public async Task<IEnumerable<ItineraryOutputDto>> GetItinerariesForUserAsync(string userId)
        {
            var itineraries = await _context.Itineraries
                 .Include(i => i.Booking)
                 .Where(i => i.Booking.UserId == userId)
                 .ToListAsync();

            return itineraries.Select(i => new ItineraryOutputDto
            {
                Id = i.Id,
                BookingId = i.BookingId,
                Details = i.Details
            });
        }
        public async Task<ItineraryOutputDto> GetItineraryByIdAsync(Guid itineraryId, string userId)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.Booking)
                .ThenInclude(b => b.TravelPackage)
                .FirstOrDefaultAsync(i => i.Id == itineraryId && i.Booking.UserId == userId);

            if (itinerary == null)
            {
                throw new Exception("Itinerary not found.");
            }

            var dto = new ItineraryOutputDto
            {
                Id = itinerary.Id,
                BookingId = itinerary.BookingId,
                Details = itinerary.Details
            };

            return dto;
        }
        public byte[] GenerateItineraryPdf(ItineraryOutputDto itinerary)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            try
            {
                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(50);
                        page.Size(PageSizes.A4);

                        page.Header()
                            .Text("Itinerary")
                            .SemiBold()
                            .FontSize(20)
                            .FontColor(Colors.Blue.Medium);

                        page.Content().PaddingVertical(10).Column(column =>
                        {
                            column.Item().Text("Itinerary Details:")
                                .Bold().FontSize(16);
                            column.Item().Text(itinerary.Details)
                                .FontSize(12);
                        });

                        page.Footer().AlignCenter().Text(txt =>
                        {
                            txt.Span("Generated on ");
                            txt.Span(DateTime.Now.ToString("MM/dd/yyyy"));
                        });
                    });
                });

                return document.GeneratePdf();
            }
            catch (Exception ex)
            {
                Console.WriteLine("PDF Generation Error: " + ex.ToString());
                throw; 
            }
        }

    }
}
