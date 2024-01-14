using MealPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Services
{
    public interface IMealService
    {
        Task<int> AddAsync(Meal meal);
        Task<int> UpdateAsync(Meal meal);
        Task<int> DeleteAsync(Meal meal);
        Task<List<Meal>> GetAsync();

    }
}
