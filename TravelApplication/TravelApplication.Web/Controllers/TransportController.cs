using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transport>> GetAllTransports()
        {
            var transports = _transportService.GetAllTransports();
            return Ok(transports);
        }

        [HttpGet("{id}")]
        public ActionResult<Transport> GetTransportById(Guid id)
        {
            var transport = _transportService.GetTransportById(id);
            if (transport == null)
            {
                return NotFound();
            }

            return Ok(transport);
        }

        [HttpPost]
        public ActionResult<Transport> AddTransport([FromBody] Transport transport)
        {
            if (transport == null)
            {
                return BadRequest("Transport data cannot be null.");
            }

            _transportService.AddTransport(transport);

            return CreatedAtAction(nameof(GetTransportById), new { id = transport.Id }, transport);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransport(Guid id, [FromBody] Transport transport)
        {
            if (transport == null || transport.Id != id)
            {
                return BadRequest("Transport data is incorrect.");
            }

            _transportService.UpdateTransport(transport);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransport(Guid id)
        {
            var transport = _transportService.GetTransportById(id);

            if (transport == null)
            {
                return NotFound();
            }

            _transportService.DeleteTransport(id);

            return NoContent();
        }
    }
}
