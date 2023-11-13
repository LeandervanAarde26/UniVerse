using System.Diagnostics;
using UniVerse.Services.SubjectServices;
using UniVerse.ViewModels;

public class StaffMemberRightBar : ContentView
{
    public SubjectViewModel _subjectViewModel;
    public Picker subjectPicker;

    public StaffMemberRightBar()
    {
        SubjectService subjectService = new SubjectService();
        _subjectViewModel = new SubjectViewModel(subjectService);

        subjectPicker = new Picker
        {
            BackgroundColor = Color.FromArgb("#F6F7FB"),
            Margin = new Thickness(0, 10),
            TextColor = Color.FromArgb("#2B2B2B"),
        };

        Label frameHeading = new Label
        {
            Text = "Assign Subject",
            TextColor = Color.FromArgb("#2B2B2B"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 24,
            Margin = new Thickness(0, 10)
        };

        Button button = new Button
        {
            Text = "Assign to Subject",
            BackgroundColor = Color.FromArgb("#2B2B2B"),
            Margin = new Thickness(0, 12)
        };

        button.Clicked += AssignSubject;

        StackLayout stack = new StackLayout
        {
            Children =
            {
                frameHeading,
                subjectPicker,
                button,
            }
        };

        Frame frame = new Frame
        {
            BackgroundColor = Colors.White,
            CornerRadius = 15,
            BorderColor = Colors.Transparent,
            Margin = new Thickness(5),
            Content = stack
        };

        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(45, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(31, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(24, GridUnitType.Star) },
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
            }
        };

        grid.Children.Add(frame);
        Grid.SetRow(frame, 1);

        Content = grid;

        GetSubjects();

        async void GetSubjects()
        {
            await _subjectViewModel.GetAllSubjects();
            foreach (var subject in _subjectViewModel.SubjectList)
            {
                subjectPicker.Items.Add(subject.subjectName);
            }
        }

        void AssignSubject(object sender, EventArgs e)
        {

            if (subjectPicker.SelectedItem != null)
            {
                string selectedSubjectName = subjectPicker.SelectedItem as string;
                Debug.WriteLine(selectedSubjectName);
            }
            else
            {
                Debug.WriteLine("No subject selected");
            }
        }


    }
}
