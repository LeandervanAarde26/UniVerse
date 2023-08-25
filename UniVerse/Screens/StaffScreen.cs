using Microsoft.Maui.Layouts;
using UniVerse.Components;
using UniVerse.ViewModels;

namespace UniVerse.Screens
{

    public class StaffScreen : ContentPage
    {
        private PeopleViewModel viewModel;
    
        public StaffScreen()
        {
            viewModel = new PeopleViewModel(new Services.RestService());
 
            Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));

            Style inputStyle = new(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromArgb("#2b2b2b") },

                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
            };

            Label pageHeading = new()
            {
                Text = "Staff",
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2B2B2B"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(15, 10, 0, 10)
            };

            Picker studentRole = new()
            {
                Style = inputStyle,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 20, 10)
            };

            FlexLayout topContainer = new()
            {
                JustifyContent = FlexJustify.SpaceBetween,
                Direction = FlexDirection.Row,
                Children = {
                    pageHeading,
                    studentRole
                }
            };

            var listOptions = new List<String>
            {
                "All Staff",
                "Admin Staff",
                "Academic Staff"
            };

            foreach (var option in listOptions)
            {
                studentRole.Items.Add(option);
            }
            studentRole.SelectedItem = "All Staff";
            studentRole.TextColor = Colors.White;
            studentRole.TitleColor = Colors.White;

            FlexLayout layout = new()
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
            };

            ScrollView scrollView = new()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Content = layout
            };

            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = 60},
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                     new ColumnDefinition { Width = new GridLength(75, GridUnitType.Star) },
                     new ColumnDefinition { Width = new GridLength(25, GridUnitType.Star) }
                }
            };

            var list = new List<String>
            {
                "Staff Member Type",
                "Admin Staff",
                "Academic Staff"
            };

            RightBar right = new("Staff Member", list);

            // Add the ContentView to the Grid
            //   grid.Children.Add(navbar);
            //Grid.SetRow(navbar, 0);
            //Grid.SetColumn(navbar, 0);
            //Grid.SetColumnSpan(navbar, 1);
            //Grid.SetRowSpan(navbar, 2);

            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 1);
            Grid.SetColumn(scrollView, 0);
            Grid.SetColumnSpan(scrollView, 1);
            grid.BackgroundColor = Color.FromArgb("#F6F7FB");

            grid.Children.Add(right);
            Grid.SetColumn(right, 1);
            Grid.SetColumnSpan(right, 2);
            Grid.SetRowSpan(right, 2);

            // Add the Flexlayout for heading to the Grid

            grid.Children.Add(topContainer);
            Grid.SetRow(topContainer, 0);
            Grid.SetColumn(topContainer, 0);

            Content = grid;

            GetAllStafMembersAsync();

            async void GetAllStafMembersAsync()
            {
                await viewModel.GetAllStaffMembers();

                layout.Children.Clear();
                foreach (var member in viewModel.StaffList)
                {
                    var card = new Cardview(member.name, member.person_system_identifier, member.email, "📚 DV300", "Staff Member");
                    layout.Children.Add(card);
                }
            }
        }

        protected override async void OnAppearing()
        {
         base.OnAppearing();
         await viewModel.GetAllStaffMembers();
        }
    }
}