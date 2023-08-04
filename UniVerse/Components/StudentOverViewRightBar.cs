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
                BarSpacing = 5,
                BarThickness = 8,
                WidthRequest = 200,
                HeightRequest = 200,
                FontSize = 12,
                MaxValue = 100,
                BarBackgroundColor = Color.FromArgb("#C2D5FF"),
                Entries = ChartData,
                VerticalOptions = LayoutOptions.Center,
                LegendText = "Achieved Credits"
            };

            Label legendLabel = new()
            {
                Text = "Achieved Credits",
                TextColor = Colors.Black
            };

            Ellipse LegendDot = new()
            {
                WidthRequest = 20,
                HeightRequest = 20,
                Fill = Color.FromArgb("#407BFF"),
            };

            var clip2 = new EllipseGeometry { Center = new Point(20 / 2, 20 / 2), RadiusX = 20 / 2, RadiusY = 20 / 2 };
            LegendDot.Clip = clip2;

            HorizontalStackLayout legend = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                   
                {
                    LegendDot,
                    legendLabel, 
                
                }
            };

            StackLayout chartContainer = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    radialBarChart,
                    legend,
                }
            };

            Frame frame = new()
            {
                BackgroundColor = Colors.White,
                CornerRadius = 15,
                BorderColor = Colors.Transparent,
                Margin = new Thickness(5),
                Content = chartContainer
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
                    new RowDefinition { Height = new GridLength(40, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(35, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(25, GridUnitType.Star) },
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