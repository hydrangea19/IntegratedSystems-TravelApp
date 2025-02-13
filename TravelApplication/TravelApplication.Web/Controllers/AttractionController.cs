using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionService _attractionService;

        public AttractionController(IAttractionService attractionService)
        {
            _attractionService = attractionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Attraction>> GetAllAttraction()
        {
            var attractions = _attractionService.GetAllAttractions();
            return Ok(attractions);
        }

        [HttpGet("{id}")]
        public ActionResult<Attraction> GetAttractionById(Guid id)
        {
            var attraction = _attractionService.GetAttractionById(id);
            if (attraction == null)
            {
                return NotFound();
            }

            return Ok(attraction);
        }
        [HttpPost]
        public ActionResult<Attraction> AddAttraction([FromBody] Attraction attraction)
        {
            if (attraction == null)
            {
                return BadRequest("Attraction data cannot be null.");
            }

            _attractionService.AddAttraction(attraction);

            return CreatedAtAction(nameof(GetAttractionById), new { id = attraction.Id }, attraction);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttraction(Guid id, [FromBody] Attraction attraction)
        {
            if (attraction == null || attraction.Id != id)
            {
                return BadRequest("Attraction data is incorrect.");
            }

            _attractionService.UpdateAttraction(attraction);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAttraction(Guid id)
        {
            var attraction = _attractionService.GetAttractionById(id);

            if (attraction == null)
            {
                return NotFound();
            }

            _attractionService.DeleteAttraction(id);

            return NoContent();
        }

    }
}

