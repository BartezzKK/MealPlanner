using MealPlanner.Pages;
using MealPlanner.Services;
using MealPlanner.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MealPlanner.Pages.View;
using MealPlanner.DAL;
using MealPlanner.DAL.Interfaces;

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
		builder.Services.AddDbContext<MPDbContext>();
		builder.Services.AddSingleton<IMealService, MealService>();
		builder.Services.AddTransient<MealPlanViewModel>();
		builder.Services.AddTransient<MealsPage>();
		builder.Services.AddTransient<MealViewModel>();
		builder.Services.AddTransient<AddMealView>();
		builder.Services.AddTransient<MealListViewModel>();
		builder.Services.AddSingleton<IMealRpository, MealRepository>();
        builder.Services.AddTransient<EditMealViewModel>();
        builder.Services.AddTransient<EditMealView>();

        var dbContext = new MPDbContext();
		dbContext.Database.EnsureCreated();
		dbContext.Dispose();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
