using Domain.Models;
using Domain.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL
{
    public class MPDbContext : DbContext
    {
        public MPDbContext()
        {
                
        }

        public MPDbContext(DbContextOptions<MPDbContext> optionsBuilder) :base(optionsBuilder)
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.Migrate();
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnection = $"Filename={PathDB.GetPath("MealPlannerV2.db3")}";
            optionsBuilder.UseSqlite(dbConnection, x => x.MigrationsAssembly(nameof(Domain)));
        }
    }
}
