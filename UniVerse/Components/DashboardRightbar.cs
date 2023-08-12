using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace UniVerse.Components;

public class DashboardRightbar : ContentView
{
        public string PageType { get; set; }
    public List<String> DropList { get; set; }
    public DashboardRightbar(string pgType)
    {

        PageType = pgType;
        Style inputStyle = new(typeof(Entry))
        {
            Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromHex("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(22, 5) },
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromHex("#2B2B2B") }
                }
        };

        ProfileView profileContainer = new();

        Label heading = new()
        {
            Text = "Upcoming Events",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromHex("#2B2B2B"),
            FontAttributes = FontAttributes.Bold,

        };


        Image defaultimage = new()
        {
            Source = ImageSource.FromFile("image_picker.png"),
            Aspect = Aspect.AspectFit,
            MaximumHeightRequest = 230,
            MaximumWidthRequest = 200,
        };


        FlexLayout innerLayout = new FlexLayout()
        {
            MaximumHeightRequest = 200,
            MaximumWidthRequest = 200,

            Direction = FlexDirection.Column,
            Children =
                {
                    defaultimage,
                }
        };

        Border border = new()
        {
            StrokeThickness = 1,
            Stroke = Color.FromHex("#2B2B2B"),
            HeightRequest = 100,
            StrokeDashOffset = 6,
            Content = innerLayout,
            BackgroundColor = Color.FromHex("#F6F7FB"),
            Margin = new Thickness(22, 8),
            Padding = new Thickness(10, 2),
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(6)
            },
        };





   
        StackLayout stack = new()
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
                {
                    heading,
                    border,
                }
        };

        FlexLayout layout = new()
        {
            BackgroundColor = Colors.White,
            Direction = FlexDirection.Column,

            JustifyContent = FlexJustify.Start,
            Children =
                {
                    profileContainer,
                    stack
                },


        };
        //FlexLayout.SetGrow(stack, 1);
        Content = layout;
    }
}

