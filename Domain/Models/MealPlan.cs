using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public DateTime MealDate { get; set; }
        [ForeignKey("Meal")]
        public int MealId { get; set; }
        public Meal Meal { get; set; } = new();
        public TypeOfMeal MealType { get; set; }
    }
}
