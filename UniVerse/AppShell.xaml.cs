using Microsoft.Maui.Controls;
//using Microsoft.UI.Xaml.Controls;
using UniVerse.Screens;
using UniVerse.Models;
using UniVerse.ViewModels;
namespace UniVerse;

public partial class AppShell : Shell
{
    private readonly Navigation _navViewModel;

	public AppShell()
	{
        InitializeComponent();
        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
        Routing.RegisterRoute(nameof(StaffMemberOverviewScreen), typeof(StaffMemberOverviewScreen));
        Routing.RegisterRoute(nameof(StudentOverviewScreen), typeof(StudentOverviewScreen));
        Routing.RegisterRoute(nameof(SubjectOverview), typeof(SubjectOverview));
        Routing.RegisterRoute(nameof(StudentScreen), typeof(StudentScreen));
        Routing.RegisterRoute(nameof(StaffScreen), typeof(StaffScreen));

        _navViewModel = new Navigation();
        Image image = new()
        {
            Source = "logo.png",
            MaximumHeightRequest = 80,
            Aspect = Aspect.Center, 
            
        };
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        FlyoutHeader = image;
        FlyoutWidth = 260;


        Button logout = new()
        {
            BackgroundColor = Color.FromArgb("#2B2B2B"),
            Text = "Logout",
            ImageSource = "logout_icon.png",
            MaximumWidthRequest = 200,
            BorderColor = Colors.Transparent
        };

        FlyoutFooter = logout;
       
        _navViewModel.AddNavItems();
        foreach (var item in _navViewModel.Items)
        {
            Items.Add(item);
       
           
        }
        FlyoutBehavior = FlyoutBehavior.Locked;
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(1000);

        var color = Color.FromArgb("#2B2B2B");
      
        FlyoutBackgroundColor = color;
        FlyoutBackground = Color.FromArgb("#2B2B2B");
   

    }

}


