using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
namespace UniVerse.Components
{
    public class StaffMemberRightBar : ContentView
    {
        public StaffMemberRightBar()
        {

            Image image = new()
            {
                Source = ImageSource.FromFile("staff_member_right_bar.png"),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 350
            };

            Label frameHeading = new()
            {
                Text = "Assign Subject",
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 24,
                Margin = new Thickness(0, 10)
            };

            SearchBar search = new()
            {
                BackgroundColor = Color.FromArgb("#F6F7FB"),
                Margin = new Thickness(0, 10),
                TextColor = Color.FromArgb("#2B2B2B"),
                Placeholder = "Search Subject",
            };


            Button button = new()
            {
                Text = "Assign to Subject ",
                BackgroundColor = Color.FromArgb("#2B2B2B"),
                Margin = new Thickness(0, 12)
            };

            StackLayout stack = new()
            {

                Children =
                {
                    frameHeading,
                    search,
                    button,
                }
            };


            Frame frame = new()
            {
                BackgroundColor = Colors.White,
                CornerRadius = 15,
                BorderColor = Colors.Transparent,
                Margin = new Thickness(5),
                Content = stack
            };
            //Chart

            //Delete
            Button delete = new()
            {
                Margin = new Thickness(8, 12),
                Text = "Delete Staff Member",
                BackgroundColor = Color.FromArgb("#FF4040"),
                ImageSource = ImageSource.FromFile("trash.png")
            };
            Debug.WriteLine(staffId);

            StackLayout deleteStack = new()
            {
                VerticalOptions = LayoutOptions.End,
                Children =
                {
                    delete
                }
            };

            //Page Content
            Grid grid = new()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(45, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(31, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(24, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                }
            };

            // Add elements to the grid
            grid.Children.Add(image);
            Grid.SetRow(image, 0);
            Grid.SetColumn(image, 0);

            grid.Children.Add(frame);
            Grid.SetRow(frame, 1);


            grid.Children.Add(deleteStack);
            Grid.SetRow(deleteStack, 2);
            //Page Content

            Content = grid;
        }
    }
}

