using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace UniVerse.Components
{


    public class RightBar : ContentView
    {
        public string PageType { get; set; }
        public List<String> DropList {get; set; }
        public RightBar(string pgType, List<String> dropLst)
        {

            PageType = pgType;
            DropList = dropLst;
            Style inputStyle = new(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromHex("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(22, 5) },
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromHex("#2B2B2B") }
                }
            };

            ProfileView profileContainer = new();

            Label heading = new()
            {
                Text = "Add new " + PageType,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(22, 5),
                TextColor = Color.FromHex("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,

            };


            Image defaultimage = new()
            {
                Source = ImageSource.FromFile("image_picker.png"),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 230,
                MaximumWidthRequest = 200,
            };

            Button imageUploadButton = new()
            {
                Text = "Upload Image",
                BackgroundColor = Colors.Transparent,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(5,0),
                TextColor = Color.FromHex("#407BFF"),
            };

            FlexLayout innerLayout = new FlexLayout()
            {
                MaximumHeightRequest = 200,
                MaximumWidthRequest = 200,

                Direction = FlexDirection.Column,
                Children =
                {
                    defaultimage,
                    imageUploadButton
                }
            };

            Border border = new()
            {
                StrokeThickness = 1,
                Stroke = Color.FromHex("#2B2B2B"),
                StrokeDashArray = new DoubleCollection(new double[] { 8, 3 }),
                HeightRequest = 230,
                StrokeDashOffset = 6,
                Content = innerLayout,
                BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(22, 8),
                Padding = new Thickness(10,2),
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(6)
                },
            };

            Entry name = new Entry()
            {
                Placeholder = PageType +  " Name",
                Style = inputStyle

            };

            Entry surname = new()
            {
                Placeholder = PageType +  " Surname",
                Style = inputStyle
            };

            Entry studentNumber = new()
            {
                Placeholder = PageType + " Number",
                Style = inputStyle
            };

            var listOptions = DropList;

            Picker studentRole = new()
            {
                Style = inputStyle,
              

            };

             foreach (var option in listOptions)
            {
                studentRole.Items.Add(option);
            }
            studentRole.SelectedItem = PageType + " Type";
            studentRole.TextColor = Colors.Black;
            studentRole.TitleColor = Colors.Black;

            StackLayout showcase = new()
            {
                
                Children =
                {
                    studentNumber,
                    studentRole
                }
            };


            FlexLayout showcase2 = new()
            {
                Direction = FlexDirection.Row,
                Children =
                {
                    studentNumber,
                    studentRole
                }
            };

            Entry email = new()
            {
                Placeholder = PageType + " Email",
                Style = inputStyle

            };

            Entry phoneNumber = new()
            {
                Placeholder =  PageType + " Number",
                Style = inputStyle,
                MaxLength = 10
            };


            Button button = new()
            {
                Text =  "Add " + PageType,
                BackgroundColor = Color.FromHex("#2B2B2B"),
                Margin = new Thickness(18, 6)
            };

            StackLayout stack = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    heading,
                    border,
                    name,
                    surname,
                    //showcase,
                    //showcase2,
                    studentNumber,
                    studentRole,
                    email,
                    phoneNumber,
                    button
                }
            };

            FlexLayout layout = new()
            {
                BackgroundColor = Colors.White,
                Direction = FlexDirection.Column,

                JustifyContent = FlexJustify.Start,
                Children =
                {
                    profileContainer,
                    stack
                },

               
            };
            //FlexLayout.SetGrow(stack, 1);
            Content = layout;
        }
    }
}
