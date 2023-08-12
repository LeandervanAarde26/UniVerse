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

        FlyoutBackgroundColor = Color.FromArgb("#2B2B2B"); 

        _navViewModel = new Navigation();
        Image image = new()
        {
            Source = "logo.png",
            MaximumHeightRequest = 80,
            Aspect = Aspect.Center, 
            
        };

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


