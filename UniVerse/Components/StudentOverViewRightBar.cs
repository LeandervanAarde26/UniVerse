using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Controls.RadialBarChart;
using UniVerse.ViewModels;

namespace UniVerse.Components
{
    public class StudentOverViewRightBar : ContentView
    {
        private readonly StudentViewModel _studentViewModel;

        public int person_id { get; set; }
        public StudentOverViewRightBar(int id) 
        {
            person_id = id;

            _studentViewModel = new StudentViewModel(new Services.StudentServices.StudentService());
            BindingContext = _studentViewModel;
            var ChartData = new ChartEntry[]
            {
                new ChartEntry
                {
                    Value = 71,
                    Color = Color.FromArgb("#407BFF"),
                
                },
            };

            

            Image image = new()
            {
                Source = ImageSource.FromFile("staff_member_right_bar.png"),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 350
            };

            RadialBarChart radialBarChart = new()
            {
                BarSpacing = 5,
                BarThickness = 12,
                WidthRequest = 350,
                HeightRequest = 250,
                FontSize = 12,
                MaxValue = 100,
                //ShowLabels = false,
                BarBackgroundColor = Color.FromArgb("#E9F0FF"),
                Entries = ChartData,
                //Margin = new Thickness(10, 5, 0, 0),
                LegendText = "Achieved Credits",
                LegendText2 = "Needed Credits"
            };

            Frame frame = new()
            {
                BackgroundColor = Colors.White,
                CornerRadius = 15,
                BorderColor = Colors.Transparent,
                Margin = new Thickness(5),
                Content = radialBarChart
            };
   
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
       
            Content = grid;

            GetUserDetails();

            async void GetUserDetails()
            {
                await _studentViewModel.GetStudent(person_id);
                radialBarChart.Entries = _studentViewModel.SingleStudentChart;
                radialBarChart.CenterText = $"{_studentViewModel.Student.FirstOrDefault().needed_credits}";
            }
        }
    }
}