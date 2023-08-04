using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniVerse.Components;

namespace UniVerse.Screens
{

    public class StudentScreen : ContentPage
    {
        public StudentScreen()
        {

            Style inputStyle = new(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromArgb("#2b2b2b") },
                
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
            };


            Label pageHeading = new()
            {
                Text = "Students",
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2B2B2B"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(15, 10, 0, 10)
            };


            Picker studentRole = new()
            {
                Style = inputStyle,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 10, 20, 10)
            };

            FlexLayout topContainer = new()
            {
                JustifyContent = FlexJustify.SpaceBetween,
                Direction = FlexDirection.Row,
                Children = {
                    pageHeading,
                    studentRole
                }
            };

            var listOptions = new List<String>
            {
                "All Students",
                "Degree Student",
                "Certificate Student"
            };

            foreach (var option in listOptions)
            {
                studentRole.Items.Add(option);
            }
            studentRole.SelectedItem = "All Students";
            studentRole.TextColor = Colors.White;
            studentRole.TitleColor = Colors.White;


            FlexLayout layout = new()
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
            };

            ScrollView scrollView = new()
            {
                VerticalOptions = LayoutOptions.Center,

                Content = layout
            };

            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = 60},
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(70, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
                }
            };

            var list = new List<String>
            {
                "Student Type",
                "Degree Student",
                "Certificate Student"
            };
            RightBar right = new("Student", list);


            // Add the ContentView to the Grid
            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 1);
            Grid.SetColumn(scrollView, 1);
            Grid.SetColumnSpan(scrollView, 1);
            grid.BackgroundColor = Color.FromArgb("#F6F7FB");

            grid.Children.Add(right);
            Grid.SetColumn(right, 2);
            Grid.SetColumnSpan(right, 2);
            Grid.SetRowSpan(right, 2);  

            // Add the Flexlayout for heading to the Grid

            grid.Children.Add(topContainer);
            Grid.SetRow(topContainer, 0);
            Grid.SetColumn(topContainer, 1);

            Content = grid;
            var numbers = new List<int> { 1, 2, 3, 4,  2, 3, 4, 5, 2, 3, 4, 5 };

            foreach (var number in numbers)
            {
                var card = new Cardview("Leander van Aarde", "Degree Student", "200211@virtualwindow.co.za", "⭐️ 120 Credits", "student");
                layout.Children.Add(card);
            }
        }
    }
}