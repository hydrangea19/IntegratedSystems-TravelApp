using Microsoft.AspNetCore.Mvc;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Service.Interface;

namespace TravelApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Meal>> GetAllMeals()
        {
            var meals = _mealService.GetAllMeals();
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public ActionResult<Meal> GetMealById(Guid id)
        {
            var meal = _mealService.GetMealById(id);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        public ActionResult<Meal> AddMeal([FromBody] Meal meal)
        {
            if (meal == null)
            {
                return BadRequest("Meal data cannot be null.");
            }

            _mealService.AddMeal(meal);

            return CreatedAtAction(nameof(GetMealById), new { id = meal.Id }, meal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeal(Guid id, [FromBody] Meal meal)
        {
            if (meal == null || meal.Id != id)
            {
                return BadRequest("Meal data is incorrect.");
            }

            _mealService.UpdateMeal(meal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeal(Guid id)
        {
            var meal = _mealService.GetMealById(id);

            if (meal == null)
            {
                return NotFound();
            }

            _mealService.DeleteMeal(id);

            return NoContent();
        }
    }
}
