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
            TextColor = Color.FromArgb("#2B2B2B"),
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
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 10)
        };

        Label welcomeMessage = new()
        {
            Text = "Welcome to Universe",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromArgb("#2B2B2B"),
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
            Aspect = Aspect.Center,
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
            HeightRequest = 250,
            BackgroundColor = Color.FromArgb("#DFE9FF"),
            Padding = new Thickness(10, 2),
            Margin = new Thickness(20, 20, 20, 20),
            StrokeThickness = 0,
            Content = welcomeInfo,
            Stroke = Color.FromArgb("#DFE9FF"),
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
            TextColor = Color.FromArgb("#2B2B2B"),
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
            TextColor = Color.FromArgb("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        Button viewStudents = new()
        {
            Text = "View Students > ",
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.End,

        };

        FlexLayout studentInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                studentsGraph,
                degreeStudentsText,
                diplomaStudentsText,
                viewStudents
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
            TextColor = Color.FromArgb("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        Label academicText = new()
        {
            Text = "Academic Staff",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromArgb("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        Button viewStaff = new()
        {
            Text = "View Staff > ",
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.End,

        };

        FlexLayout adminInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                adminGraph,
                adminStaffText,
                academicText,
                viewStaff
            }
        };


        Border studentsBanner = new()
        {
            HeightRequest = 280,
            //WidthRequest = 500,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(20, 0, 10, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = studentInfo,
            Stroke = Color.FromArgb("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };



    

        Border adminBanner = new()
        {
            HeightRequest = 280,
            //WidthRequest = 500,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(10, 0, 20, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = adminInfo,
            Stroke = Color.FromArgb("#FFFFFF"),
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
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };

        Label subjectsTitleText = new()
        {
            Text = "📚Subjects",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromArgb("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        Button viewSubjects = new()
        {
            Text = "View Subjects > ",
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.End,

        };


        FlexLayout subjectsInfo = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                subjectsNumberText,
                subjectsTitleText,
            }
        };

        Border subjects= new()
        {
            HeightRequest = 300,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(10, 20, 0, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = subjectsInfo,
            Stroke = Color.FromArgb("#FFFFFF"),
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
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        Label totalFundsText = new()
        {
            Text = "Total Funds",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromArgb("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 10, 0, 0)
        };


        Button viewFunds = new()
        {
            Text = "View Funds > ",
            TextColor = Color.FromArgb("#407BFF"),
            HorizontalOptions = LayoutOptions.End,

        };

        FlexLayout fundsTextLayout = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                fundsText,
                totalFundsText,
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
            HeightRequest = 300,
            BackgroundColor = Color.FromArgb("#FFFFFF"),
            Margin = new Thickness(10, 20, 10, 0),
            Padding = new Thickness(10, 2),
            StrokeThickness = 0,
            Content = fundsInfo,
            Stroke = Color.FromArgb("#FFFFFF"),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };

        FlexLayout bottom = new()
        {
            JustifyContent = FlexJustify.Center,
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
                new RowDefinition{Height = GridLength.Auto},
                new RowDefinition{Height = GridLength.Auto},
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
            
                new ColumnDefinition { Width = new GridLength(75, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(25, GridUnitType.Star) }
            }
        };

        DashboardRightbar right = new("Upcoming Events");

        grid.Children.Add(dashboardGrid);
        Grid.SetRow(dashboardGrid, 1);
        Grid.SetColumn(dashboardGrid, 0);
        Grid.SetColumnSpan(dashboardGrid, 1);

        grid.Children.Add(right);
        Grid.SetColumn(right, 1);
        Grid.SetColumnSpan(right, 1);
        Grid.SetRowSpan(right, 2);

        grid.Children.Add(topContainer);
        Grid.SetRow(topContainer, 0);
        Grid.SetColumn(topContainer, 0);

        Content = grid;
    }
}