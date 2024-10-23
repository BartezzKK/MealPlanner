using Domain.Models;
using Domain.Models.Enums;

namespace Domain.DAL.Interfaces
{
    public interface IMealPlanRepository
    {
        void AddAsync(MealPlan plan);
        void DeleteAsync(MealPlan plan);
        Task<List<MealPlan>> GetAsync();
        Task<MealPlan?> GetByIdAsync(int id);
        Task<MealPlan?> GetRandomByTypeAsync(TypeOfMeal type);
        Task<List<MealPlan>> GetByDate(DateTime startDate, DateTime endDate);
    }
}
