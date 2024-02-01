using CommunityToolkit.Maui.Alerts;
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddMealView));
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MealListViewModel ml = (MealListViewModel)BindingContext;
        ml.RefreshState();
    }
}
