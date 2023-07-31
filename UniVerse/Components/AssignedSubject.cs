using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniVerse.Components
{
	public class AssignedSubject : ContentView
	{
		public AssignedSubject ()
		{
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
                MaximumHeightRequest = 160,
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("development.png"),

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



            FlexLayout.SetBasis(stack, new FlexBasis(0.4f, true));

            Frame frame = new()
            {
                BackgroundColor = Color.FromHex("#DFE9FF"),
                HeightRequest = 200,
                BorderColor = Colors.Transparent,
                Content = innerLayout,
                CornerRadius = 10,
                Margin = new Thickness(12, 10)
            };


            Content = frame;
        }
	}
}