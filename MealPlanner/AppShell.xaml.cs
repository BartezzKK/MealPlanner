using MealPlanner.Pages;
using MealPlanner.Pages.View;

namespace MealPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MealsPage), typeof(MealsPage));
		Routing.RegisterRoute(nameof(AddMealView), typeof(AddMealView));
		Routing.RegisterRoute(nameof(EditMealView), typeof(EditMealView));
    }
}
