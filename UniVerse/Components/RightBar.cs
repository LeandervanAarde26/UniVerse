using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace UniVerse.Components
{
    public class RightBar : ContentView
    {
        public RightBar()
        {
            Label heading = new Label
            {
                Text = "Add Student",
                TextColor = Color.FromHex("#2B2B2B"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Margin = new Thickness(5, 3),
                FontAttributes = FontAttributes.Bold,
            };

            Style inputStyle = new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromHex("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(5, 3) }
                }
            };

            Image image = new Image
            {
                Source = ImageSource.FromFile("image_picker.png"),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit,
                HeightRequest = 170,
                Margin = new Thickness(10, 2)
            };

            Button textButton = new Button
            {
                Text = "Add Image",
                FontSize = 12,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Blue,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            Entry name = new Entry
            {
                Placeholder = "Student name",
                Style = inputStyle
            };

            Button addStudent = new Button
            {
                Text = "Add Student",
                FontSize = 15,
                BackgroundColor = Color.FromHex("#2B2B2B"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(6)
            };

            Entry surname = new Entry
            {
                Placeholder = "Student surname",
                Style = inputStyle
            };

            Entry email = new Entry
            {
                Placeholder = "Student email",
                Style = inputStyle
            };

            Entry studentNumber = new Entry
            {
                Placeholder = "Student number",
                Style = inputStyle
            };

            Picker picker = new Picker
            {
                Style = inputStyle,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            picker.Items.Add("Select Student type");
            picker.Items.Add("Degree Student");
            picker.Items.Add("Certificate Student");
            picker.SelectedItem = "Select Student type";
            picker.TextColor = Colors.Black;
            picker.TitleColor = Colors.Black;

            StackLayout row = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 6
            };

            picker.BackgroundColor = Color.FromHex("#F6F7FB");

            row.Children.Add(studentNumber);
            row.Children.Add(picker);

            Entry cell = new Entry
            {
                Placeholder = "Student cell",
                Style = inputStyle
            };

            StackLayout imagePicker = new StackLayout
            {
                BackgroundColor = Color.FromHex("#F6F7FB"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(10, 0),
                Children =
                {
                    image,
                    textButton
                }
            };

            Border border = new Border
            {
                StrokeThickness = 1,
                Stroke = Color.FromHex("#2B2B2B"),
                StrokeDashArray = new DoubleCollection(new double[] { 8, 3 }),
                StrokeDashOffset = 6,
                Content = imagePicker,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(6)
            };

            FlexLayout layout = new FlexLayout
            {
                BackgroundColor = Colors.White,
                Padding = 20,
                Direction = FlexDirection.Column,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    heading,
                    border,
                    name,
                    surname,
                    row,
                    email,
                    addStudent
                }
            };

       
            Content = new ScrollView
            {
                Content = layout
            };
        }
    }
}
