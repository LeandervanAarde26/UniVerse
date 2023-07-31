using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniVerse.Components;

namespace UniVerse.Screens
{
	public class StaffMemberOverviewScreen : ContentPage
	{
		public StaffMemberOverviewScreen()
		{
            // Top 
            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                WidthRequest = 250,
                HeightRequest = 250,
                Source = ImageSource.FromFile("allen_laing.png"),

            };
            var clip1 = new EllipseGeometry { Center = new Point(248 / 2, 248 / 2), RadiusX = 248 / 2, RadiusY = 248 / 2 };

            image.Clip = clip1;

            Border imgBorder = new()
            {
                WidthRequest = 260,
                HeightRequest = 260,
                StrokeShape = new Ellipse(),
                HorizontalOptions = LayoutOptions.Center,
                StrokeThickness = 6,
                //Margin = new Thickness(0, -7, 0, 15),
                Stroke = Color.FromHex("#407BFF"),
                Content = image

            };

            Label name = new()
            {
                Text = "Armand Pretorius",
                TextColor = Color.FromHex("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 24
            };

            Label role = new()
            {
                Text = "Academic",
                TextColor = Color.FromHex("#C5C5C5"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };

            Label hourlyRate = new()
            {
                Text = "\U0001F4B2 R400/h",
                TextColor = Color.FromHex("#2B2B2B"),
                FontSize = 16
            };

            Label cell = new()
            {
                Text = "\U0000260E 076 887 6675",
                TextColor = Color.FromHex("#2B2B2B"),
                FontSize = 16
            };

            Label mail = new()
            {
                Text = "📧 Armand@OpenWindow.co.za",
                TextColor = Color.FromHex("#2B2B2B"),
                FontSize = 16
            };


            Label address = new()
            {
                Text = "\U0001F4CD 05 Academic drive, Gauteng, Johannesburg, 1724",
                TextColor = Color.FromHex("#2B2B2B"),
                FontSize = 16
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

                FlexLayout.SetBasis(card, new FlexBasis(0.45f, true));

                layout.Children.Add(card);
            }



            ScrollView scrollView = new()
            {
         
                Content = layout
            };


            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = 290},
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(70, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
                }
            };


            grid.Children.Add(topContainer);
            Grid.SetRow(topContainer, 0);
            Grid.SetColumn(topContainer, 1);
            Grid.SetColumnSpan(topContainer, 1);

            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 1);
            Grid.SetColumn(scrollView, 1);
            Grid.SetColumnSpan(scrollView, 1);



            grid.BackgroundColor = Color.FromHex("#F6F7FB");
            grid.Padding = 6;


            Content = grid;

        }
	}
}