using MealPlanner.ViewModel;

namespace MealPlanner.Pages.View;

public partial class EditMealView : ContentPage
{
	public EditMealView(EditMealViewModel mealViewModel)
	{
		InitializeComponent();
		BindingContext = mealViewModel;
	}
}