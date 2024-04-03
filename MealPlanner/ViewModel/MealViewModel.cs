using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MealPlanner.Pages;
using CommunityToolkit.Maui.Alerts;
using Domain.Services;
using Domain.Models;

namespace MealPlanner.ViewModel
{
    public partial class MealViewModel : ObservableObject
    {
        private readonly IMealService mealService;
        public MealViewModel(IMealService mealService)
        {
            this.mealService = mealService;
        }
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string description = "";

        [ObservableProperty]
        private string name = "";

        [ObservableProperty]
        private bool isBreakfast = false;

        [ObservableProperty]
        private bool isLunch = false;

        [ObservableProperty]
        private bool isDinner = false;

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

        [ICommand]
        private async void UpdateMeal()
        {
            try
            {
                Meal meal = await mealService.GetByIdAsync(this.id);
                if (meal != null)
                {
                    await mealService.UpdateAsync(meal);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Meal ConvertToMeal(MealViewModel mealViewModel)
        {
            return new Meal()
            {
                Name = mealViewModel.name,
                Description = mealViewModel.description,
                IsBreakfast = mealViewModel.IsBreakfast,
                IsLunch = mealViewModel.IsLunch,
                IsDinner = mealViewModel.IsDinner
            };
        }

        //private MealViewModel ConvertToMealVM(Meal meal) 
        //{
        //    return new MealViewModel(mealService)
        //    {
        //        Id = meal.Id,
        //        Description = meal.Description,
        //        Name = meal.Name,
        //        IsBreakfast = meal.IsBreakfast,
        //        IsLunch = meal.IsLunch,
        //        IsDinner = meal.IsDinner
        //    };
        //}
    }
}
