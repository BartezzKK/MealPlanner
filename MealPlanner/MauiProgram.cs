using MealPlanner.Pages;
using MealPlanner.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MealPlanner.Pages.View;
using Domain.DAL;
using Domain.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Domain.Services;

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
        string dbConnection = $"Filename={GetPath("MealPlanner.db3")}";
        builder.Services.AddDbContext<MPDbContext>();
        builder.Services.AddSingleton<IMealService, MealService>();
        builder.Services.AddSingleton<IMealPlanService, MealPlanService>();
        //builder.Services.AddTransient<MealPlanViewModel>();
        builder.Services.AddTransient<MealsPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<MealViewModel>();
		builder.Services.AddTransient<AddMealView>();
		builder.Services.AddTransient<MealListViewModel>();
		builder.Services.AddSingleton<IMealRpository, MealRepository>();
		builder.Services.AddSingleton<IMealPlanRepository, MealPlanRepository>();
        builder.Services.AddTransient<EditMealViewModel>();
        builder.Services.AddTransient<EditMealView>();
        builder.Services.AddTransient<MealPlansViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        //builder.UseSqlite(dbConnection, x => x.MigrationsAssembly(nameof(MealPlanner.Domain)));
        return builder.Build();
	}

    public static string GetPath(string dbName)
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbName);
#if WINDOWS || IOS
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbPath);
#endif
        return dbPath;
    }
}
