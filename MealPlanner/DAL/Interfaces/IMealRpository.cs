using MealPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.DAL.Interfaces
{
    public interface IMealRpository
    {
        void AddAsync(Meal meal);
        void UpdateAsync(Meal meal);
        void DeleteAsync(Meal meal);
        Task<List<Meal>> GetAsync();
        Task<Meal> GetByIdAsync(int id);
    }
}
