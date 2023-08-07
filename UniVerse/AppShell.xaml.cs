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
       
        _navViewModel = new Navigation();
        Image image = new()
        {
            Source = "logo.png",
            MaximumHeightRequest = 80,
            Aspect = Aspect.Center, 
            
        };


       
        FlyoutHeader = image;
        FlyoutWidth = 260;
        FlyoutBehavior = FlyoutBehavior.Locked;
        FlyoutBackgroundColor = Color.FromArgb("#2B2B2B");
        FlyoutBackground = Color.FromArgb("#2B2B2B");
        

        Button logout = new()
        {
            BackgroundColor = Color.FromArgb("#000000"),
            Text = "Logout",
            ImageSource = "logout_icon.png",
            MaximumWidthRequest = 200
        };

        FlyoutFooter = logout;
       

        _navViewModel.AddNavItems();
        foreach (var item in _navViewModel.Items)
        {
            Items.Add(item);
           
        }        
    }

}


