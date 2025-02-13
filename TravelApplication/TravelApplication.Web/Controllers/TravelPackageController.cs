using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.DTO;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {
        private readonly ITravelPackageService _travelPackageService;

        public TravelPackageController(ITravelPackageService travelPackageService)
        {
            _travelPackageService = travelPackageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TravelPackage>> GetAllTravelPackages()
        {
            var travelPackages = _travelPackageService.GetAllTravelPackages();
            return Ok(travelPackages);
        }

        [HttpGet("{id}")]
        public ActionResult<TravelPackage> GetTravelPackageById(Guid id)
        {
            var travelPackage = _travelPackageService.GetTravelPackageDetails(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            return Ok(travelPackage);
        }
        [HttpPost]
        public IActionResult AddTravelPackage([FromBody] TravelPackageDTO travelPackageDTO)
        {
            if (travelPackageDTO == null)
            {
                return BadRequest("TravelPackage cannot be null.");
            }

            try
            {
                TravelPackage travelPackage = _travelPackageService.AddTravelPackage(travelPackageDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTravelPackage(Guid id, [FromBody] TravelPackage travelPackage)
        {
            if (travelPackage == null || travelPackage.Id != id)
            {
                return BadRequest("Mismatched travel package or invalid data.");
            }

            try
            {
                _travelPackageService.UpdateTravelPackage(travelPackage);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTravelPackage(Guid id)
        {
            var existingPackage = _travelPackageService.GetTravelPackageById(id);
            if (existingPackage == null)
            {
                return NotFound();
            }

            try
            {
                _travelPackageService.DeleteTravelPackage(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }

}

