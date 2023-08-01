using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniVerse.Components
{
	public class AssignedSubject : ContentView

	{

        public float CornerRadius { get; set; }
        public AssignedSubject ()
		{
            CornerRadius = 20;
            Label subjectName = new()
            {
             
                Text = "Interactive Development",
                TextColor = Color.FromHex("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };

            Label subjectCode = new()
            {
                Text = "IDV 300",
                TextColor = Color.FromHex("#717171"),
                FontSize = 14
            };



            StackLayout stack = new()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
 
                Children =
                {
                      subjectName,
                      subjectCode
                }
            };


            Image subjectImage = new()
            {

                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 180,
                VerticalOptions = LayoutOptions.Center,
                Source = "devreplace.png",
                Margin = new Thickness(0, 0, 20, 0)


            };

  

            FlexLayout innerLayout = new()
            {
                Direction = FlexDirection.Row,
                Children =
                {
                    subjectImage,
                    stack
                }

            };


            Frame frame = new()
            {
                CornerRadius = 20,
                HeightRequest = 240,
                BackgroundColor = Color.FromHex("#DFE9FF"),
                BorderColor = Color.FromHex("#DFE9FF"),
                Margin = new Thickness(12, 10),
     
                Content = innerLayout,
           
            };

            Content = frame;
        }
	}
}