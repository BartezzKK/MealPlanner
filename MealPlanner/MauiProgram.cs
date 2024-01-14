using MealPlanner.Pages;
using MealPlanner.Services;
using MealPlanner.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MealPlanner.Pages.View;

namespace MealPlanner;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<IMealService, MealService>();
		builder.Services.AddTransient<MealPlanViewModel>();
		builder.Services.AddTransient<MealsPage>();
		builder.Services.AddTransient<MealViewModel>();
		builder.Services.AddTransient<AddMealView>();
		builder.Services.AddTransient<MealListViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
