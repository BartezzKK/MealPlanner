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
            await mealService.AddAsync(ConvertToMeal(this));
            await Shell.Current.GoToAsync("..");
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
