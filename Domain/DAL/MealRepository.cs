using Domain.Models;
using Domain.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Domain.DAL
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

        public async Task<int> CountByType(TypeOfMeal type)
        {
            switch (type)
            {
                case TypeOfMeal.Breakfast:
                    return await context.Meals.Where(p=> p.IsBreakfast).OrderBy(p => p.Id).CountAsync();
                case TypeOfMeal.Lunch:
                    return await context.Meals.Where(p=> p.IsLunch).OrderBy(p => p.Id).CountAsync();
                case TypeOfMeal.Dinner:
                    return await context.Meals.Where(p=> p.IsDinner).OrderBy(p => p.Id).CountAsync();
                default:
                    return 0;
            }
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

        public async Task<Meal> GetByIdAsync(int id)
        {
            return await context.Meals.FindAsync(id);
        }

        public async Task<Meal?> GetRandomMealByType(TypeOfMeal type)
        {
            int count = await CountByType(type);
            Random r = new Random();

            switch (type)
            {
                case TypeOfMeal.Breakfast:
                    return await context.Meals.Where(p => p.IsBreakfast).OrderBy(p=> p.Id).Skip(r.Next(count)).Take(1).FirstOrDefaultAsync();
                case TypeOfMeal.Lunch:
                    return await context.Meals.Where(p => p.IsLunch).OrderBy(p => p.Id).Skip(r.Next(count)).Take(1).FirstOrDefaultAsync();
                case TypeOfMeal.Dinner:
                    return await context.Meals.Where(p => p.IsDinner).OrderBy(p => p.Id).Skip(r.Next(count)).Take(1).FirstOrDefaultAsync();
                default:
                    throw new NotImplementedException();
            }
        }

        public async void UpdateAsync(Meal meal)
        {
            context.Meals.Update(meal);
            await context.SaveChangesAsync();
        }
    }
}
