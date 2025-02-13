using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Implementation;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetAllActivities()
        {
            var activities = _activityService.GetAllActivities();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivityById(Guid id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }
        [HttpPost]
        public ActionResult<Activity> AddActivity([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest("Activity data cannot be null.");
            }

            _activityService.AddActivity(activity);

            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivity(Guid id, [FromBody] Activity activity)
        {
            if (activity == null || activity.Id != id)
            {
                return BadRequest("Activity data is incorrect.");
            }

            _activityService.UpdateActivity(activity);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(Guid id)
        {
            var activity = _activityService.GetActivityById(id);

            if (activity == null)
            {
                return NotFound();
            }

            _activityService.DeleteActivity(id);

            return NoContent();
        }

    }
}
