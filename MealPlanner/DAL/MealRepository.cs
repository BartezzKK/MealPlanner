using MealPlanner.DAL.Interfaces;
using MealPlanner.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.DAL
{
    public class MealRepository : IMealRpository
    {
        private readonly MPDbContext context;

        public MealRepository(MPDbContext context)
        {
            this.context = context;
        }
        public async void AddAsync(Meal meal)
        {
            await context.Meals.AddAsync(meal);
            await context.SaveChangesAsync();
        }

        public async void DeleteAsync(Meal meal)
        {
            context.Meals.Remove(meal);
            await context.SaveChangesAsync();
        }

        public async Task<List<Meal>> GetAsync()
        {
            return await context.Meals.ToListAsync();
        }

        public async void UpdateAsync(Meal meal)
        {
            context.Meals.Update(meal);
            await context.SaveChangesAsync();
        }
    }
}
