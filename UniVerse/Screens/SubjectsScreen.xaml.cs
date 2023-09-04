using UniVerse.ViewModels;

namespace UniVerse.Screens;

public partial class SubjectsScreen : ContentPage
{
    private SubjectViewModel viewModel;

    public SubjectsScreen()
	{
		InitializeComponent();

        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
        viewModel = new SubjectViewModel(new Services.SubjectServices.SubjectService());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.GetAllSubjects();

        foreach (var subject in viewModel.SubjectList)
        {
            var subjectCard = new Components.SubjectCard
            {
                BindingContext = subject
            };
            subjectStackLayout.Children.Add(subjectCard);
        }
    }
}
