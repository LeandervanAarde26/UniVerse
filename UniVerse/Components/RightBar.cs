using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using System;

namespace UniVerse.Components
{
    public class RightBar : ContentView
    {
        public RightBar()
        {

            Image image = new()
            {
                Source = ImageSource.FromFile("image_picker.png"),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit,
                HeightRequest = 110,
                Margin = new Thickness(2)
            };

            Button textButton = new()
            {
                Text = "Add Image",
                FontSize = 12,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Blue,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(0, 0, 0, 0)
            };


            Entry name = new()
            {
                Placeholder = "Student name",
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(5, 6)
            };



            Entry surname = new()
            {
                Placeholder = "Student surname",
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(5,5)
            };


            Entry email = new()
            {
                Placeholder = "Student email",
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(6,0)
            };

            Entry studentNumber = new()
            {
                Placeholder = "Student number",
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(6, 0),
            };


            Picker picker = new()
            {
                Title = "Student Type",
            };

            picker.Items.Add("Degree Student");
            picker.Items.Add("Certificate Student");



            StackLayout row = new()
            {
                Orientation = StackOrientation.Horizontal,
               Padding = 6
            };

            studentNumber.HorizontalOptions = LayoutOptions.StartAndExpand;
            picker.HorizontalOptions = LayoutOptions.StartAndExpand;
            picker.BackgroundColor = Color.FromHex("#F6F7FB");

            row.Children.Add(studentNumber);
            row.Children.Add(picker);


            
            ContentView container = new()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content  = row
            };

        

            Entry cell = new()
            {
                Placeholder = "Student surname",
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(6)
            };
            StackLayout imagePicker = new ()
            {
                BackgroundColor =Color.FromHex("#F6F7FB"),
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 200,
                Padding = 10,
                Children =
                {
                    image,
                    textButton,

                }

            };
            Border border = new ()
            {
                StrokeThickness = 1,
                Stroke = Color.FromHex("#2B2B2B"),
                StrokeDashArray = new DoubleCollection(new double[] { 8, 3 }),
                StrokeDashOffset = 6,
                Content = imagePicker,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(6),
               
            };

            FlexLayout layout = new FlexLayout
            {
                BackgroundColor = Colors.White,
                Padding = 20,
                Direction = FlexDirection.Column,
                Children =
                {
                    border,
                    name,
                   surname,
                    container,
                    email,
                    cell
                }
            };

            Content = layout;
        }
    }
}
