using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace UniVerse.Components;

public class Navbar : ContentView
{
    public string PageType { get; set; }
	public Navbar()
	{
       
        Image defaultimage = new()
        {
            //HeightRequest = 0,
            //WidthRequest = 450,
            Source = ImageSource.FromFile("navlogo.png"),
            //BackgroundColor = Color.FromHex("#FFFFFF")
        };



        ImageButton dashboardIcon = new()
        {
            Source = ImageSource.FromFile("dashboard.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label dashboardText = new()
        {
            Text = "Dashboard",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout dashboardStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                dashboardIcon,
                dashboardText
            }
        };

        ImageButton studentsIcon = new()
        {
            //HeightRequest = 10,
            //WidthRequest = 10,
            Source = ImageSource.FromFile("teacher.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label studentsText = new()
        {
            Text = "Students",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout studentsStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                studentsIcon,
                studentsText
            }
        };




        ImageButton staffIcon = new()
        {
            HeightRequest = 10,
            WidthRequest = 10,
            Source = ImageSource.FromFile("profile.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label staffText = new()
        {
            Text = "Staff",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout staffStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                staffIcon,
                staffText
            }
        };





        ImageButton subjectsIcon = new()
        {
            HeightRequest = 10,
            WidthRequest = 10,
            Source = ImageSource.FromFile("book.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label subjectsText = new()
        {
            Text = "Subjects",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout subjectsStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                subjectsIcon,
                subjectsText
            }
        };




        ImageButton fundsIcon = new()
        {
            HeightRequest = 10,
            WidthRequest = 10,
            Source = ImageSource.FromFile("coin.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label fundsText = new()
        {
            Text = "Funds",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout fundsStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                fundsIcon,
                fundsText
            }
        };



        ImageButton logoutIcon = new()
        {
            HeightRequest = 10,
            WidthRequest = 10,
            Source = ImageSource.FromFile("logout.png"),
            Margin = new Thickness(30, 0, 0, 50) // Add a margin at the bottom of the ImageButton
        };

        Label logoutText = new()
        {
            Text = "Logout",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#FFFFFF"),
            FontAttributes = FontAttributes.Bold,

        };

        HorizontalStackLayout logoutStack = new()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                logoutIcon,
                logoutText
            }
        };


        VerticalStackLayout logo = new()
        {
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10, 0, 0),

            Children =
            {
                defaultimage,
            }
        };
        VerticalStackLayout stack = new()
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                dashboardStack,
                studentsStack,
                staffStack,
                subjectsStack,
                fundsStack
            }
        };
        VerticalStackLayout logoutVStack = new()
        {
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10, 0, 0),
            Children =
            {
                logoutStack,
            }
        };


        FlexLayout layout = new()
        {
            BackgroundColor = Color.FromHex("#2B2B2B"),
            Direction = FlexDirection.Column,

            JustifyContent = FlexJustify.SpaceEvenly,
            Children =
                {
                logo,
                    stack,
                    logoutVStack
                },


        };
        FlexLayout.SetGrow(logo, 10);       // 20% for logo
        FlexLayout.SetGrow(stack, 80);      // 80% for stack
        FlexLayout.SetGrow(logoutStack, 10);
        Content = layout;
    }
}

