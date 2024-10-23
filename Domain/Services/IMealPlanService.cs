using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IMealPlanService
    {
        Task<int> AddAsync(MealPlan mealPlan);
        Task<int> UpdateAsync(MealPlan mealPlan);
        Task<int> DeleteAsync(int id);
        Task<List<MealPlan>> GetAsync();
        Task<MealPlan> GetByIdAsync(int id);
        Task<MealPlan> GetRandomPlan(TypeOfMeal type);
        Task<List<MealPlan>> GetPlansForWeek();
    }
}
