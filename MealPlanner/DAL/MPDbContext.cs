using MealPlanner.Model;
using MealPlanner.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.DAL
{
    public class MPDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnection = $"Filename={PathDB.GetPath("MealPlanner.db3")}";
            optionsBuilder.UseSqlite(dbConnection);
        }
    }
}
