using System;
using System.Diagnostics;
using UniVerse.ViewModels;

namespace UniVerse.Screens;

public partial class SubjectOverview : ContentPage
{
    public int SubjectId { get; set; }
    private readonly SubjectViewModel _viewModel;

    public SubjectOverview()
	{
		InitializeComponent();
        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));

        _viewModel = new SubjectViewModel(new Services.RestService());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SubjectOverviewViewModel viewModel)
        {
            if (viewModel.NavigationParameter is int id)
            {
                Debug.WriteLine(id);
            }

            var subject = await _viewModel.GetSubject(SubjectId);
            Debug.WriteLine(subject.subject_id);
        }
    }
}
