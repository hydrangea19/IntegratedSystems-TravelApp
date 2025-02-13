using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Destination>> GetAllDestinations()
        {
            var destinations = _destinationService.GetAllDestinations();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public ActionResult<Destination> GetDestinationById(Guid id)
        {
            var destination = _destinationService.GetDestinationById(id);
            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        [HttpPost]
        public ActionResult<Destination> AddDestination([FromBody] Destination destination)
        {
            if (destination == null)
            {
                return BadRequest("Destination data cannot be null.");
            }

            _destinationService.AddDestination(destination);

            return CreatedAtAction(nameof(GetDestinationById), new { id = destination.Id }, destination);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDestination(Guid id, [FromBody] Destination destination)
        {
            if (destination == null || destination.Id != id)
            {
                return BadRequest("Destination data is incorrect.");
            }

            _destinationService.UpdateDestination(destination);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDestination(Guid id)
        {
            var destination = _destinationService.GetDestinationById(id);

            if (destination == null)
            {
                return NotFound();
            }

            _destinationService.DeleteDestination(id);

            return NoContent();
        }
    }
}
