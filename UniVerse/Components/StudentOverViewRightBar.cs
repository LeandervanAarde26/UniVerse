using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Controls.RadialBarChart;

namespace UniVerse.Components
{
    public class StudentOverViewRightBar : ContentView
    {
        public StudentOverViewRightBar()
        {
            var ChartData = new ChartEntry[]
            {
                new ChartEntry
                {
                    Value = 71,
                    Color = Color.FromArgb("#407BFF"),
                    Text = "Visual Studio Code"
                },
            };


            Image image = new()
            {
                Source = ImageSource.FromFile("staff_member_right_bar.png"),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 350
            };

            //Chart
            RadialBarChart radialBarChart = new()
            {
                BarSpacing = 0,
                BarThickness = 8,
                WidthRequest = 400,
                HeightRequest = 400,
                FontSize = 12,
                MaxValue = 100,
                BarBackgroundColor = Color.FromArgb("#E9F0FF"),
                Entries = ChartData,
                VerticalOptions = LayoutOptions.Center,
                LegendText = "Achieved Credits",
                LegendText2 = "Needed Credits"
            };


            StackLayout chartContainer = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    radialBarChart,
                }
            };

            Frame frame = new()
            {
                BackgroundColor = Colors.White,
                CornerRadius = 15,
                BorderColor = Colors.Transparent,
                Margin = new Thickness(5),
                Content = radialBarChart
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

            StackLayout deleteStack = new()
            {
                VerticalOptions = LayoutOptions.End,
                Children =
                {
                    delete
                }
            };
            //Delete

            //Page Content
            Grid grid = new()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(45, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(40, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(20, GridUnitType.Star) },
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