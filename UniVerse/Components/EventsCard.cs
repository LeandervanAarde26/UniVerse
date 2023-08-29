using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UniVerse.Components
{
    public class EventsCard : ContentView
    {
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventOrganiser { get; set; }
        public EventsCard(string evname, string evDate, string evOrganiser)
        {
            EventName = evname;
            EventDate = evDate;
            EventOrganiser = evOrganiser;

            Label eventName = new()
            {
                Text = EventName,
                FontAttributes = FontAttributes.Bold,
                FontSize = 15, 
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.FromArgb("#2b2b2b")
            };

            Label date = new()
            {
                Text = EventDate,
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.FromArgb("#A7A7A7")
            };

            Label organiser = new()
            {
                Text = EventOrganiser,
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.FromArgb("#A7A7A7")
            };


            StackLayout textLayout = new()
            {
              
                Children =
                {
                    eventName, 
                    date,
                    organiser,
                }

            };

            Image image = new()
            {
                Source = ImageSource.FromFile("event_image.png"),
                Aspect = Aspect.AspectFill,
            
                HeightRequest = 100,
            };

            FlexLayout layout = new()
            {
                Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
                Children = {
                    textLayout,
                    image
                }
            };


            Frame frame = new()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start,
           
                HeightRequest = 120,
                BackgroundColor = Color.FromArgb("#F6F7FB"),
                BorderColor = Color.FromArgb("#F6F7FB"),
                Margin = new Thickness(20, 10),
                Content = layout
            };

            Content = frame;
        }
    }
}