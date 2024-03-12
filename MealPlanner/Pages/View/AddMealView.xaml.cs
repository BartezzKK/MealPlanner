using MealPlanner.ViewModel;

namespace MealPlanner.Pages.View;

public partial class AddMealView : ContentPage
{
	public AddMealView(MealViewModel mealViewModel)
	{
		InitializeComponent();
		BindingContext = mealViewModel;
	}

}
