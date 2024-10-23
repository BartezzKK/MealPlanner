using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using MealPlanner.Pages.View;
using Domain.Services;
using Domain.Models;


namespace MealPlanner.ViewModel
{
    public partial class MealListViewModel : ObservableObject
    {
        private readonly IMealService mealService;
        public MealListViewModel(IMealService mealService)
        {
            Meals = new ObservableCollection<Meal>();
            this.mealService = mealService;
            //GetMeals();
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

        [ICommand]
        async void RemoveMeal(Meal meal)
        {
            await mealService.DeleteAsync(meal.Id);
            Meals.Remove(meal);
            await Toast.Make($"Posiłek {meal.Name} został usunięty", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
        }

        [ICommand]
        async void EditMeal(Meal meal)
        {
            var navPar = new Dictionary<string, object>();
            navPar.Add("MealDetail", meal);
            await Shell.Current.GoToAsync(nameof(EditMealView), navPar);
        }

        public void RefreshState()
        {
            Meals.Clear();
            GetMeals();
        }

    }
}
