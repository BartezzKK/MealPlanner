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
    public partial class MealListViewModel : ObservableObject
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
            List<Meal> meals = new();
            try
            {
                meals = await mealService.GetAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            foreach(var meal in meals) 
            {
                Meals.Add(meal);
            };
        }

    }
}
