using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniVerse.Controls.RadialBarChart;

namespace UniVerse.Screens
{
    public class Tester : ContentPage
    {
        public Tester()
        {

           var  ChartData = new ChartEntry[]
{
            new ChartEntry
            {
                Value = 71,
                Color = Color.FromArgb("#6023FF"),
                Text = "Visual Studio Code"
            },
};


            RadialBarChart radialBarChart = new()
            {
                BarSpacing = 5,
                BarThickness = 8,
                WidthRequest = 360,
                HeightRequest = 360,
                FontSize = 12,
                MaxValue = 100,
                //ShowLabels = false,
                BarBackgroundColor = Colors.White,
                Entries = ChartData
            };

            StackLayout stackLayout = new()
            {
                WidthRequest =450,
                HeightRequest = 450,
                BackgroundColor = Colors.Orange,

                Children =
                {
                    radialBarChart
                }
            };


            Content = stackLayout;
        }
    }
}