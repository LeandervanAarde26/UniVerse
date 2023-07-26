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
            FlexLayout layout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
            };

            ScrollView scrollView = new()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,

                Content = layout
            };

            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
        new ColumnDefinition { Width = new GridLength(6, GridUnitType.Star) },
        new ColumnDefinition { Width = new GridLength(74, GridUnitType.Star) },
        new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
                }
            };


            RightBar right = new();


            // Add the ContentView to the Grid
            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 0);
            Grid.SetColumn(scrollView, 1);
            Grid.SetColumnSpan(scrollView, 1);

            grid.Children.Add(right);
            Grid.SetRow(right, 0);
            Grid.SetColumn(right, 2);
            Grid.SetColumnSpan(right, 2);

            Content = grid;
            var numbers = new List<int> { 1, 2, 3, 4,  2, 3, 4, 5, 2, 3, 4, 5 };

            foreach (var number in numbers)
            {
                var card = new Cardview();
                layout.Children.Add(card);

            }
        }
    }
}