using MealPlanner.ViewModel;

namespace MealPlanner.Pages.View;

public partial class AddMealView : ContentPage
{
	//private MealViewModel mealViewModel { get; set; }
	public AddMealView(MealViewModel mealViewModel)
	{
		InitializeComponent();
		BindingContext = mealViewModel;
	}

}
