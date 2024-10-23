using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IMealService
    {
        Task<int> AddAsync(Meal meal);
        Task<int> UpdateAsync(Meal meal);
        Task<int> DeleteAsync(int id);
        Task<List<Meal>> GetAsync();
        Task<Meal> GetByIdAsync(int id);
        Task<Meal> GetRandomMealByType(TypeOfMeal typeOfMeal);
    }
}
