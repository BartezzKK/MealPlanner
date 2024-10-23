using CommunityToolkit.Maui.Alerts;
using MealPlanner.ViewModel;

namespace MealPlanner.Pages;

public partial class HomePage : ContentPage
{
    private readonly MealPlansViewModel _mealPlansViewModel;
    public HomePage(MealPlansViewModel mealPlansViewModel)
	{
		InitializeComponent();
        _mealPlansViewModel = mealPlansViewModel;
        BindingContext = _mealPlansViewModel;
        //mealPlans.ItemsSource = GetMealPlans();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!await CheckPermissions())
        {
            await Toast.Make("Not all permissions were accepted. Application will close.").Show();
            Application.Current.Quit();
        }
        await _mealPlansViewModel.RefreshPlansAsync();
    }
    private async Task<bool> CheckPermissions()
    {
        PermissionStatus mediaStatus = await CheckPermissions<Permissions.Media>();
        PermissionStatus storageWriteStatus = await CheckPermissions<Permissions.StorageWrite>();
        PermissionStatus storageReadStatus = await CheckPermissions<Permissions.StorageRead>();


        return IsGranted(mediaStatus) && IsGranted(storageWriteStatus) && IsGranted(storageReadStatus);
    }
    private async Task<PermissionStatus> CheckPermissions<TPermission>() where TPermission : Permissions.BasePermission, new()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<TPermission>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<TPermission>();
        }

        return status;
    }

    private static bool IsGranted(PermissionStatus status)
    {
        return status == PermissionStatus.Granted || status == PermissionStatus.Limited;
    }

}