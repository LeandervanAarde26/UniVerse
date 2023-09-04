using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UniVerse.Components
{
    public class EnrolledSubjects : ContentView
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectColor { get; set; }

        public EnrolledSubjects(string name, string code, string color)
        {
            SubjectName = name;
            SubjectCode = code;
            SubjectColor = color;

            Label subjectName = new()
            {

                Text = SubjectName,
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            Label subjectCode = new()
            {
                Text = SubjectCode,
                TextColor = Color.FromArgb("#717171"),
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,

            };

            StackLayout stack = new()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                      subjectName,
                      subjectCode,
                    
                }
            };


            Image subjectImage = new()
            {
                Source = "devreplace.png",
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(-10, 0, 10, 0),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 150,

            };



            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = new GridLength(85, GridUnitType.Star) },
                    new RowDefinition{Height = new GridLength(15, GridUnitType.Star) }
                      
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(60, GridUnitType.Star) }
                }
            };

            grid.Children.Add(subjectImage);
            Grid.SetRow(subjectImage, 0);
            Grid.SetColumn(subjectImage, 0);

            grid.Children.Add(stack);
            Grid.SetRow(stack, 0);
            Grid.SetColumn(stack, 1);

            grid.Children.Add(mark);
            Grid.SetRow(mark, 1);
            Grid.SetColumn(mark, 1);

            Frame frame = new()
            {
                CornerRadius = 20,
                HeightRequest = 240,
                BackgroundColor = Color.FromArgb(SubjectColor),
                BorderColor = Color.FromArgb(SubjectColor),
                Margin = new Thickness(12, 10),

                Content = grid,

            };

            Content = frame;
        }
    }
}