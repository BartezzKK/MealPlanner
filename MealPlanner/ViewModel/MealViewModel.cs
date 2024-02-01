using CommunityToolkit.Mvvm.ComponentModel;
using MealPlanner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MealPlanner.Services;
using MealPlanner.Pages;
using CommunityToolkit.Maui.Alerts;

namespace MealPlanner.ViewModel
{
    public partial class MealViewModel : ObservableObject
    {
        private readonly IMealService mealService;
        public MealViewModel(IMealService mealService)
        {
            this.mealService = mealService;
        }
        //[ObservableProperty]
        //private int id;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string name;

        [ICommand]
        private async void SaveMeal()    
        {
            try
            {
                int result = await mealService.AddAsync(ConvertToMeal(this));
                if (result == 0)
                {
                    await Toast.Make($"Wystąpił błąd podczas zapisywania posiłku", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
                else
                {
                    await Shell.Current.GoToAsync("///MealsPage", true);
                    await Toast.Make($"Nowy posiłek został dodany", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Wystąpił błąd podczas dodawania posiłku", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        private Meal ConvertToMeal(MealViewModel mealViewModel)
        {
            return new Meal()
            {
                Name = mealViewModel.name,
                Description = mealViewModel.description
            };
        }
    }
}
