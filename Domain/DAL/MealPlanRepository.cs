using Domain.DAL.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly MPDbContext _context;
        public MealPlanRepository(MPDbContext context)
        {
            this._context = context;
        }
        public async void AddAsync(MealPlan plan)
        {
            await _context.MealPlans.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async void DeleteAsync(MealPlan plan)
        {
            _context.Remove(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MealPlan>> GetAsync()
        {
            return await _context.MealPlans.Include(p => p.Meal).ToListAsync();
        }

        public async Task<List<MealPlan>> GetByDate(DateTime startDate, DateTime endDate)
        {
            return await _context.MealPlans.Include(p=> p.Meal).Where(p => p.MealDate >= startDate && p.MealDate <= endDate).OrderBy(p => p.MealDate).ToListAsync();
        }

        public async Task<MealPlan?> GetByIdAsync(int id)
        {
            return await _context.MealPlans.Include(p => p.Meal).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<MealPlan?> GetRandomByTypeAsync(TypeOfMeal type)
        {
            Random r = new Random();
            int i = 0;
            MealPlan plan = null;
            if (_context.MealPlans.Any(p=> p.MealType == type))
            {
                while (i < 10)
                {
                    int rowId = r.Next(1, _context.MealPlans.Count());
                    plan = await _context.MealPlans.Include(p => p.Meal).FirstOrDefaultAsync(p => p.Id == rowId);
                    if (plan?.MealType == type) break;
                }
            }
            return plan;
        }
    }
}
