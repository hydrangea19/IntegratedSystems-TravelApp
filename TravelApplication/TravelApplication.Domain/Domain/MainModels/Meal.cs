using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.DomainTypes;
using TravelApplication.Domain.Domain.MappingModels;

namespace TravelApplication.Domain.Domain.MainModels
{
    public class Meal : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Cuisine { get; set; }
        public bool? IsVegetarian { get; set; }
        public bool? IsHalal { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public MealType? Type { get; set; }
        public string? ImageUrl { get; set; }

        public virtual IEnumerable<TravelPackageMeal>? PackageMeals { get; set; }
    }
}
