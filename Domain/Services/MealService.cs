using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Domain.DAL;
using Domain.DAL.Interfaces;

namespace Domain.Services
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

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                Meal meal = await mealRepository.GetByIdAsync(id);
                if (meal != null)
                {
                    mealRepository.DeleteAsync(meal);
                    return meal.Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<List<Meal>> GetAsync()
        {
            return await mealRepository.GetAsync();
        }

        public async Task<Meal> GetByIdAsync(int id)
        {
            return await mealRepository.GetByIdAsync(id);
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
