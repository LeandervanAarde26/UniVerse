using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UniVerse.Components
{
    public class Cardview : ContentView
    {

        public Cardview()
        {
            // var primaryColor = (Color)Application.Current.Resources["white"];
            //Components added inside
            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 125,
                HeightRequest = 125,
                Source = ImageSource.FromFile("allen_laing.png"),
                
            };
            var clip1 = new EllipseGeometry { Center = new Point(125 / 2, 125 / 2), RadiusX = 125 / 2, RadiusY = 125 / 2 };

            image.Clip = clip1;

            Border imgBorder = new()
            {
                WidthRequest = 130,
                HeightRequest = 130,
                StrokeShape = new Ellipse(),
                HorizontalOptions = LayoutOptions.Center,
                StrokeThickness = 6,
                Margin = 0,
                Stroke = Colors.Blue,
                Content = image

            };

            Label name = new()
            {
                Text = "Name",
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            Label role = new()
            {
                Text = "Degree student",
                TextColor = Color.FromHex("#717171"),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center
            };


            Label email = new()

            {
                Text = "\U0001F4E7 200211@virtualWindow.co.za",
                TextColor = Color.FromHex("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };

            Label additionalInformation = new()
            {
                Text = "\u2B50 Credits",
                TextColor = Color.FromHex("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };


            Grid grid = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Star },

                    new RowDefinition { Height = 40 },
                    new RowDefinition { Height = 30 },
                    new RowDefinition { Height = 30 },
                    new RowDefinition { Height = 30 },
                },

            };

            // Add elements to the grid with their respective row indices
            grid.Children.Add(imgBorder);
            Grid.SetRow(imgBorder, 0);

            grid.Children.Add(name);
            Grid.SetRow(name, 1);

            grid.Children.Add(role);
            Grid.SetRow(role, 2);

            grid.Children.Add(email);
            Grid.SetRow(email, 3);

            grid.Children.Add(additionalInformation);
            Grid.SetRow(additionalInformation, 4);

            Ellipse ell = new()
            {
                Stroke = Colors.Red,
                StrokeThickness = 5,
                WidthRequest = 200,
                HeightRequest = 200
            };




            Frame frame = new()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 380,
                BackgroundColor = Colors.White,
                Margin = new Thickness(20),
                Content = grid,

            };

            Content = frame;
        }
    }
}