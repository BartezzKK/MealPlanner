using MealPlanner.Model;
using MealPlanner.Pages.View;
using MealPlanner.ViewModel;

namespace MealPlanner.Pages;

public partial class MealsPage : ContentPage
{
    public MealsPage(MealListViewModel mealListViewModel)
    {
        InitializeComponent();
        BindingContext = mealListViewModel;
    }

    //private List<Meal> GetMeals()
    //{
    //    return new List<Meal>
    //    {
    //        new Meal{Id=1, Description="Lorem ipsum 1", Name="Jajeczniczka" },
    //        new Meal{Id=2, Description="Lorem ipsum 2", Name="Chlebek" },
    //        new Meal{Id=3, Description="Lorem ipsum 3", Name="Tosty" },
    //        new Meal{Id=4, Description="Lorem ipsum 4", Name="Omlet" }
    //    };
    //}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddMealView));
    }
}
