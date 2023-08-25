using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniVerse.ViewModels;

namespace UniVerse.Components
{
    public class ProfileView : ContentView
    {
        private LoginViewModel loginViewModel;
        public ProfileView() {

            loginViewModel = new LoginViewModel(new Services.RestService(), Navigation);
           

            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 60,
                HeightRequest = 60,
                Source = ImageSource.FromFile("allen_laing.png"),

            };
            var clip1 = new EllipseGeometry { Center = new Point(60 / 2, 60 / 2), RadiusX = 60 / 2, RadiusY = 60 / 2 };

            image.Clip = clip1;

            Label username = new()
            {
                Text = "Leander van Aarde",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            Label role = new()
            {
                Text = "Admin",
                FontSize = 14,
                TextColor = Colors.DarkGray,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };


            StackLayout information = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 6, 0),
                Children =
                {
                    username, role,
                }

            };


            Grid profileContainer = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{ Height = GridLength.Auto },
                },


                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = GridLength.Star },
                 new ColumnDefinition { Width = GridLength.Auto }
                },
          
                Padding = new Thickness(6),
                Margin = new Thickness(22, 5),
            };
            profileContainer.Children.Add(image);
         
            profileContainer.MinimumHeightRequest = 65;

            Grid.SetRow(image, 0);
            Grid.SetColumn(image, 1);

            profileContainer.Children.Add(information);
            Grid.SetRow(information, 0);
            Grid.SetColumn(information, 0);


            Content = profileContainer;
        }
    }
}