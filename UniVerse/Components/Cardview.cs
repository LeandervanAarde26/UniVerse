using Microsoft.Maui.Controls.Shapes;
using UniVerse.ViewModels;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Graphics;
using System.Data;
using UniVerse.Screens;

namespace UniVerse.Components
{

    public class Cardview : ContentView
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string AdditionalInformation { get; set; }

        public string Buttontext { get; set; }

        public Cardview(string nme, string rle, string eml, string addinfo, string btnText, int id)
        {

            Name = nme;
            Role = rle;
            Email = eml;
            AdditionalInformation = addinfo;
            Buttontext = btnText;

            Image image = new()
            {
                Aspect = Aspect.AspectFill,

                WidthRequest = 125,
                HeightRequest = 125,
                Source = ImageSource.FromFile("arras.png"),

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
                Margin = new Thickness(0, -7, 0, 15),
                Stroke = Color.FromArgb("#407BFF"),
                Content = image

            };

            ImageButton editButton = new()
            {
                Source = ImageSource.FromFile("edit.png"),
                HeightRequest = 25,
                WidthRequest = 25,
                Aspect = Aspect.Center,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
            };

            Label name = new()
            {
                Text = Name,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
            };

            Label role = new()
            {
                Text = Role,
                TextColor = Color.FromArgb("#717171"),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };


            Label email = new()
            //200211@virtualWindow.co.za"
            {
                Text = "\U0001F4E7"  + Role,
                TextColor = Color.FromArgb("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 15, 0, 0)
            };

            //\u2B50 120 Credits

            Label additionalInformation = new()
            {
                Text = AdditionalInformation,
                TextColor = Color.FromArgb("#717171"),
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };

            Button textButton = new()
            {
                Text = "View " + Buttontext,
                FontSize = 18,
                BackgroundColor = Colors.Transparent,
                TextColor = Color.FromArgb("#407BFF"),
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 0, 0, 0)
            };

            var cardViewModel = new CardViewModel();
            textButton.Clicked += async (sender, e) =>
            {
                await cardViewModel.NavigateToOverviewScreenAsync(Buttontext, id);
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
                VerticalOptions = LayoutOptions.Fill,
               
                WidthRequest = 260,
                BackgroundColor = Colors.White,
                Margin = new Thickness(20),
                Content = stack,
                BorderColor = Colors.White,

            };

            Content = frame;
        }
    }
}