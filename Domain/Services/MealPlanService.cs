
using Domain.DAL.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMealPlanRepository mealPlanRepository;

        public MealPlanService(IMealPlanRepository mealPlanRepository)
        {
            this.mealPlanRepository = mealPlanRepository;
        }
        public Task<int> AddAsync(MealPlan mealPlan)
        {
            try
            {
                mealPlanRepository.AddAsync(mealPlan);
                return Task.FromResult(mealPlan.Id);
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                MealPlan mealPlan = await mealPlanRepository.GetByIdAsync(id);
                if(mealPlan != null)
                {
                    mealPlanRepository.DeleteAsync(mealPlan);
                    return mealPlan.Id;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<MealPlan>> GetAsync()
        {
            return await mealPlanRepository.GetAsync();
        }

        public async Task<MealPlan> GetByIdAsync(int id)
        {
            return await mealPlanRepository.GetByIdAsync(id);
        }

        public async Task<List<MealPlan>> GetPlansForWeek()
        {
            return await mealPlanRepository.GetByDate(DateTime.Today, DateTime.Today.AddDays(6));
        }

        public async Task<MealPlan> GetRandomPlan(TypeOfMeal type)
        {
            return await mealPlanRepository?.GetRandomByTypeAsync(type);
        }

        public Task<int> UpdateAsync(MealPlan mealPlan)
        {
            throw new NotImplementedException();
        }
    }
}
