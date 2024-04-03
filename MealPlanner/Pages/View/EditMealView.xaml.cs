using MealPlanner.ViewModel;

namespace MealPlanner.Pages.View;

public partial class EditMealView : ContentPage
{
	public EditMealView(EditMealViewModel mealViewModel)
	{
		InitializeComponent();
		BindingContext = mealViewModel;
	}

    private void btnEnableEdit_Clicked(object sender, EventArgs e)
    {
		entryName.IsEnabled = true;
		entryDescription.IsEnabled = true;
		cbIsBreakfast.IsEnabled = true;
		cbIsLunch.IsEnabled = true;
		cbIsDinner.IsEnabled = true;
		btnSave.IsVisible = true;
		btnEnableEdit.IsVisible = false;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		BindingContext = null;//sprawdziæ to czy dzia³a
    }
}