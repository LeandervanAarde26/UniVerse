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

            Style inputStyle = new (typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromHex("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(5, 3) }
                }
            };

            Image image = new()
            {
                Source = ImageSource.FromFile("image_picker.png"),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit,
                HeightRequest = 170,
                Margin = new Thickness(10,2)
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
                Style = inputStyle,
                BackgroundColor = Color.FromHex("#F6F7FB"),
             
            };



            Entry surname = new()
            {
                Placeholder = "Student surname",
                Style = inputStyle
            };


            Entry email = new()
            {
                Placeholder = "Student email",
                Style = inputStyle
            };

            Entry studentNumber = new()
            {
                Placeholder = "Student number",
                Style = inputStyle
            };


            Picker picker = new()
            {
                Style = inputStyle,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
   
            };

            picker.Items.Add("Select Student type");
            picker.Items.Add("Degree Student");
            picker.Items.Add("Certificate Student");
            picker.SelectedItem = "Select Student type";
            picker.TextColor = Colors.Black;
            picker.TitleColor = Colors.Black;



            StackLayout row = new()
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 6
            };

            FlexLayout row2 = new()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Direction = FlexDirection.Row,
                Children =
                {
                       studentNumber,
                       picker
                }
            };

   
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
                Style = inputStyle
            };
            StackLayout imagePicker = new ()
            {
                BackgroundColor =Color.FromHex("#F6F7FB"),
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 260,
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

            FlexLayout layout = new ()
            {
                BackgroundColor = Colors.White,
                Padding = 20,
                Direction = FlexDirection.Column,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    border,
                    name,
                   surname,
                    studentNumber,
                    picker,
                    email,
                    cell
                }
            };

            Content = layout;
        }
    }
}
