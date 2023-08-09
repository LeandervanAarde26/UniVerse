using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using UniVerse.Components;

namespace UniVerse.Screens;

public class Dashboard : ContentPage
{
    public Dashboard()
    {
        Label pageHeading = new()
        {
            Text = "Dashboard",
            FontSize = 32,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 10)
        };

        FlexLayout topContainer = new()
        {
            JustifyContent = FlexJustify.SpaceBetween,
            Direction = FlexDirection.Row,
            BackgroundColor = Color.FromArgb("#F6F7FB"),

        Children = {
                pageHeading,
            }
        };

        Label welcomeHeading = new()
        {
            Text = "Hello, User",
            FontSize = 32,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromHex("#407BFF"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 10)
        };

        Label welcomeMessage = new()
        {
            Text = "Welcome to Universe",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 10)
        };

        FlexLayout welcomeInfoText = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                welcomeHeading,
                welcomeMessage
            }
        };

        Image welcomeImage = new()
        {
            Source = ImageSource.FromFile("dashboard_welcome.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 630,
            MaximumWidthRequest = 600,
        };

        FlexLayout welcomeInfo = new()
        {
            JustifyContent = FlexJustify.SpaceBetween,
            Direction = FlexDirection.Row,
            Children = {
                welcomeInfoText,
                welcomeImage
            }
        };

        Border welcomeBanner = new Border
        {
            HeightRequest = 230,
            BackgroundColor = Color.FromHex("#DFE9FF"),
            Padding = new Thickness(10, 2),
            Margin = new Thickness(50, 20),
            StrokeThickness = 0,
            Content = welcomeInfo,
            Stroke = Color.FromHex("#DFE9FF"),
            HorizontalOptions = LayoutOptions.FillAndExpand,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(20)
                },
        };



        Image studentsGraph = new()
        {
            Source = ImageSource.FromFile("image_picker.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 150,
            //MaximumWidthRequest = 200,
        };

        Label degreeStudentsText = new()
        {
            Text = "Degree Students",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        RadioButton degreeStudent = new()
        {
            Content = "Red"
        };

        Label diplomaStudentsText = new()
        {
            Text = "Diploma Students",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        FlexLayout studentInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                studentsGraph,
                degreeStudentsText,
                diplomaStudentsText
            }
        };


        Image adminGraph = new()
        {
            Source = ImageSource.FromFile("image_picker.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 150,
            //MaximumWidthRequest = 200,
        };

        Label adminStaffText = new()
        {
            Text = "Admin Staff",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        Label academicText = new()
        {
            Text = "Academic Staff",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        FlexLayout adminInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                adminGraph,
                adminStaffText,
                academicText
            }
        };


        Border studentsBanner = new()
        {
            HeightRequest = 280,
            WidthRequest = 500,
            BackgroundColor = Color.FromHex("#FFFFFF"),
            Margin = new Thickness(0, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = studentInfo,
            Stroke = Color.FromHex("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };



    

        Border adminBanner = new()
        {
            HeightRequest = 280,
            WidthRequest = 500,
            BackgroundColor = Color.FromHex("#FFFFFF"),
            Margin = new Thickness(0, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = adminInfo,
            Stroke = Color.FromHex("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };



        Label subjectsNumberText = new()
        {
            Text = "20",
            FontSize = 32,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#407BFF"),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        Label subjectsTitleText = new()
        {
            Text = "📚Subjects",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };



        FlexLayout subjectsInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                subjectsNumberText,
                subjectsTitleText
            }
        };

        Border subjects= new()
        {
            HeightRequest = 250,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(20, 20),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = subjectsInfo,
            Stroke = Color.FromHex("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };


        Image fundsImage = new()
        {
            Source = ImageSource.FromFile("dashboard_funds.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 150,
            //MaximumWidthRequest = 200,
        };

        Label fundsText = new()
        {
            Text = "R100 000",
            FontSize = 32,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#407BFF"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        Label totalFundsText = new()
        {
            Text = "Total Funds",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        FlexLayout fundsTextLayout = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                fundsText,
                totalFundsText
            }
        };


        FlexLayout fundsInfo = new()
        {
            JustifyContent = FlexJustify.Start,  
            Direction = FlexDirection.Row,
            Children = {
                fundsImage,
                fundsTextLayout
            }
        };

        Border funds = new()
        {
            HeightRequest = 250,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(20, 20),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = fundsInfo,
            Stroke = Color.FromHex("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };

        FlexLayout bottom = new()
        {
            JustifyContent = FlexJustify.SpaceBetween,
            Direction = FlexDirection.Row,
            Children = {
                subjects,
                funds
            }
        };
        FlexLayout.SetBasis(subjects, new FlexBasis(0.40f, true));
        FlexLayout.SetBasis(funds, new FlexBasis(0.60f, true));

        Grid dashboardGrid = new()
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{Height = GridLength.Auto}, 
                new RowDefinition{Height = GridLength.Star},
                new RowDefinition{Height = GridLength.Star},
            },

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) }
            }
        };

        dashboardGrid.Children.Add(welcomeBanner);
        dashboardGrid.Children.Add(studentsBanner);
        dashboardGrid.Children.Add(adminBanner);
        dashboardGrid.Children.Add(bottom);

        Grid.SetRow(welcomeBanner, 0);
        Grid.SetColumn(welcomeBanner, 0);
        Grid.SetColumnSpan(welcomeBanner, 2);

        Grid.SetRow(studentsBanner, 1);
        Grid.SetColumn(studentsBanner, 0);

        Grid.SetRow(adminBanner, 1);
        Grid.SetColumn(adminBanner, 1);

        Grid.SetRow(bottom, 2);
        Grid.SetColumn(bottom, 0);
        Grid.SetColumnSpan(bottom, 2);

        dashboardGrid.BackgroundColor = Color.FromArgb("#F6F7FB");

        Grid grid = new()
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{Height = 60},
                new RowDefinition{Height = GridLength.Star}
            },

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(15, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(66, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
            }
        };

        DashboardRightbar right = new("Upcoming Events");

        grid.Children.Add(dashboardGrid);
        Grid.SetRow(dashboardGrid, 1);
        Grid.SetColumn(dashboardGrid, 1);
        Grid.SetColumnSpan(dashboardGrid, 1);

        grid.Children.Add(right);
        Grid.SetColumn(right, 2);
        Grid.SetColumnSpan(right, 2);
        Grid.SetRowSpan(right, 2);

        grid.Children.Add(topContainer);
        Grid.SetRow(topContainer, 0);
        Grid.SetColumn(topContainer, 1);

        Content = grid;
    }
}