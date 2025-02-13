using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface IMealService
    {
        List<Meal> GetAllMeals();
        Meal GetMealById(Guid id);
        void AddMeal(Meal meal);
        void UpdateMeal(Meal meal);
        void DeleteMeal(Guid id);
    }
}
