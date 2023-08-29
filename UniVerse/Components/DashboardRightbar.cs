using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using UniVerse.Models;
using UniVerse.ViewModels;

namespace UniVerse.Components;

public class DashboardRightbar : ContentView
{
    public string PageType { get; set; }
    public List<String> DropList { get; set; }
    public  List<Events> Events { get; set; }

    private readonly EventsViewModel _eventsViewModel;
    public DashboardRightbar(string pgType)

    {
        PageType = pgType;
        _eventsViewModel = new EventsViewModel(new Services.EventsServices.EventsService());
        Style inputStyle = new(typeof(Entry))
        {
            Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromArgb("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(22, 5) },
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
        };

        ProfileView profileContainer = new();

        Label heading = new()
        {
            Text = "Upcoming Events",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(22, 5),
            TextColor = Color.FromArgb("#2B2B2B"),
            FontAttributes = FontAttributes.Bold,

        };


        //EventsCard card = new EventsCard("International Cultural Exchange Fair", "Saturday, 08 July 2023" , "Maggie De Vos");

        StackLayout stack = new()
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
                {
                    heading
                }
        };

        ScrollView scrollView = new()
        {
            MaximumHeightRequest = 500,
        };
        FlexLayout layout = new()
        {
            BackgroundColor = Colors.White,
            Direction = FlexDirection.Column,
            JustifyContent = FlexJustify.Start,

            Children =
                {
                    profileContainer,
                    stack,
                    scrollView,
                },
        };

        GetAllEvents();

        async void GetAllEvents()
        {
            await _eventsViewModel.GetAllEvents();
            StackLayout scrollContent = new StackLayout();
            foreach (var ev in _eventsViewModel.EventsList)
            {
                EventsCard card = new EventsCard(ev.event_name, ev.event_date, ev.staff_organiser);
                scrollContent.Children.Add(card);
            }
            scrollView.Content = scrollContent;
        }

        //FlexLayout.SetGrow(stack, 1);
        Content = layout;
    }
}

