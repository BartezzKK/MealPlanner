using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MealPlanner.Model;
using MealPlanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.ViewModel
{
    public partial class MealListViewModel :ObservableObject
    {
        private readonly IMealService mealService;
        public MealListViewModel(IMealService mealService)
        {
            Meals = new ObservableCollection<Meal>();
            this.mealService = mealService;
            GetMeals();
        }
        [ObservableProperty]
        private ObservableCollection<Meal> meals = new();

        [ICommand]
        async void GetMeals()
        {
            List<Meal> mealss = await mealService.GetAsync();
            Meals.Add(new Meal { Id = 1, Description = "Lorem ipsum 1", Name = "Jajeczniczka" });
            Meals.Add(new Meal { Id = 2, Description = "Lorem ipsum 2", Name = "Chlebek" });
            Meals.Add(new Meal { Id = 3, Description = "Lorem ipsum 3", Name = "Tosty" });
            Meals.Add(new Meal { Id = 4, Description = "Lorem ipsum 4", Name = "Omlet" });
        }

    }
}
