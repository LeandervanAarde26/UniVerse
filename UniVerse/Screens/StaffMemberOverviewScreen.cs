
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using UniVerse.Components;

namespace UniVerse.Screens
{
	public class StaffMemberOverviewScreen : ContentPage
	{
		public StaffMemberOverviewScreen()
		{
            Style textStyle = new(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value =  16},

                    new Setter { Property = Label.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
            };

            // Top 
            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                WidthRequest = 230,
                HeightRequest = 230,
                Source = ImageSource.FromFile("allen_laing.png"),

            };
            
            var clip1 = new EllipseGeometry { Center = new Point(230 / 2, 230 / 2), RadiusX = 230 / 2, RadiusY = 230 / 2 };

            image.Clip = clip1;

            Border imgBorder = new()
            {
                WidthRequest = 235,
                HeightRequest = 235,
                StrokeShape = new Ellipse(),
                HorizontalOptions = LayoutOptions.Center,
                StrokeThickness = 6,
                //Margin = new Thickness(0, -7, 0, 15),
                Stroke = Color.FromArgb("#407BFF"),
                Content = image

            };

            Label name = new()
            {
                Text = "Armand Pretorius",
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 24
            };

            Label role = new()
            {
                Text = "Academic",
                TextColor = Color.FromArgb("#C5C5C5"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };

            Label hourlyRate = new()
            {
                Text = "\U0001F4B2 R400/h",
                Style = textStyle,
                Margin = new Thickness(0, 20, 0, 0)
            };

            Label cell = new()
            {
                Text = "\U0000260E 076 887 6675",
                Style = textStyle,
            };

            Label mail = new()
            {
                Text = "📧 Armand@OpenWindow.co.za",
                Style = textStyle,
            };


            Label address = new()
            {
                Text = "\U0001F4CD 05 Academic drive, Gauteng, Johannesburg, 1724",
                Style = textStyle,
            };


            StackLayout stackLayout = new()
            {
                Padding = new Thickness(10, 0),
                Margin = new Thickness(30, 15, 0, 0),

                Children =
                {
                    name,
                    role,
                    hourlyRate,
                    cell,
                    mail,
                    address
                }
            };

            FlexLayout topContainer = new()
            {
                Direction = FlexDirection.Row,

                Children =
                {

                    imgBorder,
                    stackLayout,

                }
            };

            // Cards 



            FlexLayout layout = new()
            {

                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
              
            };


            var numbers = new List<int> { 1, 2, 3, 4, 2, 3, 4, 5, 2, 3, 4, 5 };

            foreach (var number in numbers)
            {
                var card = new AssignedSubject();

                FlexLayout.SetBasis(card, new FlexBasis(0.50f, true));

                layout.Children.Add(card);
            }



            ScrollView scrollView = new()
            {
             
                Content = layout
            };

            StaffMemberRightBar right = new();


            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = 245},
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = new GridLength(70, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) }
                }
            };


            grid.Children.Add(topContainer);
            Grid.SetRow(topContainer, 0);
            Grid.SetColumn(topContainer, 0);
            Grid.SetColumnSpan(topContainer, 1);

            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 1);
            Grid.SetColumn(scrollView, 0);
            Grid.SetColumnSpan(scrollView, 1);
            grid.BackgroundColor = Color.FromArgb("#F6F7FB");


            grid.Children.Add(right);
            Grid.SetColumn(right, 1);
            Grid.SetColumnSpan(right, 2);
            Grid.SetRowSpan(right, 2);


            grid.BackgroundColor = Color.FromArgb("#F6F7FB");
            grid.Padding = 6;


            Content = grid;

        }
	}
}