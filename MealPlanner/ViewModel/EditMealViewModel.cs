using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MealPlanner.Model;
using MealPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.ViewModel
{
    [QueryProperty(nameof(EditMeal), "MealDetail")]
    public partial class EditMealViewModel : ObservableObject
    {
        private readonly IMealService mealService;
        [ObservableProperty]
        Meal editMeal;

        public EditMealViewModel(IMealService mealService)
        {
            this.mealService = mealService;
            EditMeal = new Meal();
        }

        [ICommand]
        private async void UpdateMeal()
        {
            try
            {
                Meal meal = await mealService.GetByIdAsync(this.EditMeal.Id);
                if (meal != null)
                {
                    await mealService.UpdateAsync(meal);

                    await Shell.Current.GoToAsync("///MealsPage", true);
                    await Toast.Make($"Posiłek został zaktualizowany", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
