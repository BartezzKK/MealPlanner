using MealPlanner.Model;

namespace MealPlanner.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        mealPlans.ItemsSource = GetMealPlans();
	}

    private List<MealPlan> GetMealPlans()
    {

        return new List<MealPlan>
        {
            new MealPlan{Id =1, Meal = new Meal{ Id = 1, Name = "Placki", Description="Placki opis" }, MealDate = new DateTime(2023,12,10) },
            new MealPlan{Id =2, Meal = new Meal{ Id = 2, Name = "Placki2", Description="Placki opis2" }, MealDate = new DateTime(2023,12,11) },
            new MealPlan{Id =3, Meal = new Meal{ Id = 3, Name = "Placki3", Description="Placki opis3" }, MealDate = new DateTime(2023,12,12) },
            new MealPlan{Id =4, Meal = new Meal{ Id = 4, Name = "Placki4", Description="Placki opis4" }, MealDate = new DateTime(2023,12,13) },
            new MealPlan{Id =5, Meal = new Meal{ Id = 5, Name = "Placki5", Description="Placki opis5" }, MealDate = new DateTime(2023,12,14) },
            new MealPlan{Id =6, Meal = new Meal{ Id = 6, Name = "Placki5", Description="Placki opis5" }, MealDate = new DateTime(2023,12,14) },
            new MealPlan{Id =7, Meal = new Meal{ Id = 7, Name = "Placki5", Description="Placki opis5" }, MealDate = new DateTime(2023,12,14) }
        };

    }
}