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
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.GetAllSubjects();
    }
}
