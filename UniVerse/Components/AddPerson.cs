using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace UniVerse.Components
{
    public class AddPerson : ContentView
    {
        public AddPerson()
        {

            Label label = new()
            {
                Text = "Add New Student",
                FontSize = 24,
                TextColor = Colors.Black
            };


            StackLayout stack = new()
            {
                BackgroundColor = Color.FromHex("#F6F7FB"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 100,
                WidthRequest = 150,
                
            };
        
















            FlexLayout layout = new()
            {
                Children =
                {
                   stack
                }
            };



            Content = layout;
        }
    }
}