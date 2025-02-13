using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class MealService : IMealService
    {
        private readonly IRepository<Meal> _mealRepository;

        public MealService(IRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public void AddMeal(Meal meal)
        {
            if (meal == null)
            {
                throw new ArgumentException(nameof(meal), "Meal data cannot be null.");
            }
            _mealRepository.Insert(meal);
        }

        public void DeleteMeal(Guid id)
        {
            Meal meal = _mealRepository.Get(id);
            if (meal != null)
            {
                _mealRepository.Delete(meal);
            }
        }

        public List<Meal> GetAllMeals()
        {
            return _mealRepository.GetAll().ToList();
        }

        public Meal GetMealById(Guid id)
        {
            return _mealRepository.Get(id);
        }

        public void UpdateMeal(Meal meal)
        {
            _mealRepository.Update(meal);
        }
    }
}
