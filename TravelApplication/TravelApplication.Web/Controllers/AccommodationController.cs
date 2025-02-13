using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService _accommodationService;

        public AccommodationController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Accommodation>> GetAllAccommodations()
        {
            var accommodations = _accommodationService.GetAllAccommodations();
            return Ok(accommodations);
        }

        [HttpGet("{id}")]
        public ActionResult<Accommodation> GetAccommodationById(Guid id)
        {
            var accommodation = _accommodationService.GetAccommodationById(id);

            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        [HttpPost]
        public ActionResult<Accommodation> AddAccommodation([FromBody] Accommodation accommodation)
        {
            if (accommodation == null)
            {
                return BadRequest("Accommodation data cannot be null.");
            }

            _accommodationService.AddAccommodation(accommodation);

            return CreatedAtAction(nameof(GetAccommodationById), new { id = accommodation.Id }, accommodation);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccommodation(Guid id, [FromBody] Accommodation accommodation)
        {
            if (accommodation == null || accommodation.Id != id)
            {
                return BadRequest("Accommodation data is incorrect.");
            }

            _accommodationService.UpdateAccommodation(accommodation);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAccommodation(Guid id)
        {
            var accommodation = _accommodationService.GetAccommodationById(id);

            if (accommodation == null)
            {
                return NotFound();
            }

            _accommodationService.DeleteAccommodation(id);

            return NoContent();
        }
    }
}
