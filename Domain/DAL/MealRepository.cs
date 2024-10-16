﻿using Domain.Models;
using Domain.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async void UpdateAsync(Meal meal)
        {
            context.Meals.Update(meal);
            await context.SaveChangesAsync();
        }
    }
}
