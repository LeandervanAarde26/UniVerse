using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Graphics;

namespace UniVerse.Components
{
    public class Cardview : ContentView
    {

        public Cardview()
        {
            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 125,
                HeightRequest = 125,
                Source = ImageSource.FromFile("allen_laing.png"),

            };
            var clip1 = new EllipseGeometry { Center = new Point(124 / 2, 124 / 2), RadiusX = 124 / 2, RadiusY = 124 / 2 };

            image.Clip = clip1;

            Border imgBorder = new()
            {
                WidthRequest = 130,
                HeightRequest = 130,
                StrokeShape = new Ellipse(),
                HorizontalOptions = LayoutOptions.Center,
                StrokeThickness = 6,
                Margin = new Thickness(0, -25, 0, 15),
                Stroke = Colors.Blue,
                Content = image

            };

            ImageButton editButton = new()
            {
                HeightRequest = 7,
                WidthRequest = 7,
                Source = ImageSource.FromFile("edit.png"),
                Aspect = Aspect.Center,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
            };

           

            Label name = new()
            {
                Text = "Name",
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
               

            };


            Label role = new()
            {
                Text = "Degree student",
                TextColor = Color.FromHex("#717171"),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };


            Label email = new()

            {
                Text = "\U0001F4E7 200211@virtualWindow.co.za",
                TextColor = Color.FromHex("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 15, 0, 0)
            };

            Label additionalInformation = new()
            {
                Text = "\u2B50 120 Credits",
                TextColor = Color.FromHex("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };

            Button textButton = new()
            {
                Text = "View Student",
                FontSize = 18,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Blue,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(0, 20, 0, 0)
            };



            StackLayout stack = new()
            {
                Children =
                {
                    editButton,
                    imgBorder,
                    name,
                    role,
                    email,
                    additionalInformation,
                    textButton
                }
            };


            Frame frame = new()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 380,
                WidthRequest = 300,
                BackgroundColor = Colors.White,
                Margin = new Thickness(20),
                Content = stack

            };

            Content = frame;
        }
    }
}