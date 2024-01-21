using MealPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MealPlanner.Services
{
    public class MealService : IMealService
    {
        private SQLiteAsyncConnection connection;
        public MealService() 
        {
            SetupDatabase();
        }
        public Task<int> AddAsync(Meal meal) => connection.InsertAsync(meal);

        public Task<int> DeleteAsync(Meal meal) => connection.DeleteAsync(meal);

        public async Task<List<Meal>> GetAsync() => await connection.Table<Meal>().ToListAsync();

        public Task<int> UpdateAsync(Meal meal) => connection.UpdateAsync(meal);

        private async void SetupDatabase()
        {
            if(connection is null)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MealPlanner.db3");
#if WINDOWS || IOS

                dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MealPlanner.db3");

#endif 
                connection = new SQLiteAsyncConnection(dbPath);
                await connection.CreateTableAsync<Meal>();
            }
        }
    }
}
