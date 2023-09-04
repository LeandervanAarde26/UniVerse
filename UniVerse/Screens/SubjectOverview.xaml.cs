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

        _viewModel = new SubjectViewModel(new Services.SubjectServices.SubjectService());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is NavOverviewViewModel viewModel)
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
