using MealPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Microsoft.Maui.Controls.PlatformConfiguration;
using MealPlanner.DAL;
using MealPlanner.DAL.Interfaces;

namespace MealPlanner.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRpository mealRepository;
        //private SQLiteAsyncConnection connection;
        public MealService(IMealRpository mealRepository) 
        {
            //SetupDatabase();
            this.mealRepository = mealRepository;
        }

        public Task<int> AddAsync(Meal meal)
        {
            try
            {
                mealRepository.AddAsync(meal);
                return Task.FromResult(meal.Id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(0);
            }
        }

        public Task<int> DeleteAsync(Meal meal)
        {
            try
            {
                mealRepository.DeleteAsync(meal);
                return Task.FromResult(meal.Id);
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }

        public async Task<List<Meal>> GetAsync()
        {
            return await mealRepository.GetAsync();
        }

        public Task<int> UpdateAsync(Meal meal)
        {
            try
            {
                mealRepository.UpdateAsync(meal);
                return Task.FromResult(meal.Id);
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }
    }
}
