using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using UniVerse.Components;


namespace UniVerse.Screens;

public class LoginScreen : ContentPage
{
    public LoginScreen()
    {

        Style inputStyle = new(typeof(Entry))
        {
            Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromHex("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(15, 5) },
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromHex("#2B2B2B") },
                }
        };

        Image loginMainImage = new()
        {
            Source = ImageSource.FromFile("login_image.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 730,
            MaximumWidthRequest = 700,
        };


        Label loginTitle = new()
        {
            Text = "Sign In",
            FontSize = 32,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 10)
        };


        Label emailLabel = new()
        {
            Text = "Email",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 0)
        };

        Entry email = new Entry()
        {
            Placeholder ="Email",
            Style = inputStyle

        };


        Label passwordLabel = new()
        {
            Text = "Password",
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.FromHex("#2B2B2B"),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 10, 0, 0)
        };
        Entry password = new()
        {
            Placeholder ="Password",
            Style = inputStyle,
        };

        Button signinButton = new()
        {
            Text = "Sign In" ,
            BackgroundColor = Color.FromHex("#2B2B2B"),
            Margin = new Thickness(18, 6)
        };

        FlexLayout login = new()
        {
            JustifyContent = FlexJustify.Center,
            Direction = FlexDirection.Column,
            Children = {
                loginTitle,
                emailLabel,
                email,
                passwordLabel,
                password,
                signinButton
            }
        };

        Border loginCard = new Border
        {
            WidthRequest = 500,
            HeightRequest = 450,
            BackgroundColor = Color.FromHex("#DFE9FF"),
            Padding = new Thickness(10, 2),
            Margin = new Thickness(50, 20),
            StrokeThickness = 0,
            Content = login,
            Stroke = Color.FromHex("#DFE9FF"),
            HorizontalOptions = LayoutOptions.FillAndExpand,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20)
            },
        };

        Grid grid = new()
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{Height = GridLength.Star}
            },

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(60, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) },
            }
        };

        grid.BackgroundColor = Color.FromHex("#FFFFFF");


        grid.Children.Add(loginMainImage);
        Grid.SetRow(loginMainImage, 1);
        Grid.SetColumn(loginMainImage, 0);
        Grid.SetColumnSpan(loginMainImage, 1);

        grid.Children.Add(loginCard);
        Grid.SetRow(loginCard, 1);
        Grid.SetColumn(loginCard, 1);
        Grid.SetColumnSpan(loginCard, 1);

        //grid.Children.Add(right);
        //Grid.SetColumn(right, 2);
        //Grid.SetColumnSpan(right, 2);
        //Grid.SetRowSpan(right, 2);


        Content = grid;
    }
}
