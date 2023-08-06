using Microsoft.Maui.Controls;
//using Microsoft.UI.Xaml.Controls;
using UniVerse.Screens;

namespace UniVerse;

public partial class AppShell : Shell
{
	public AppShell()
	{
        
        ShellContent staffFlyoutContent = new()
        {
            ContentTemplate = new (() => new StaffScreen())
        };
        Image image = new()
        {
            Source = "logo.png",
            MaximumHeightRequest = 80,
            Aspect = Aspect.Center,
         
        };

        FlyoutHeader = image;
        FlyoutBackgroundColor = Color.FromArgb("#2B2B2B");
        FlyoutWidth = 250;
        

        FlyoutItem staffFlyoutItem = new()
        {
            Title = "Staff",
            //FlyoutIcon = "cat.png"
        };

    

        staffFlyoutItem.Items.Add(new Tab
        {
            Items = { staffFlyoutContent }
        });

        staffFlyoutItem.CurrentItem = staffFlyoutContent;

        Items.Add(staffFlyoutItem);

        FlyoutBehavior = FlyoutBehavior.Locked;
    }
}

    //<ShellContent
    //    Title = "Home"
    //    ContentTemplate="{DataTemplate local:MainPage}"
    //    Route="MainPage" />