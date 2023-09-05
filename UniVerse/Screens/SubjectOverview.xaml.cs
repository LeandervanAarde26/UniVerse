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
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is NavOverviewViewModel viewModel)
        {
            if (viewModel.NavigationParameter is int id)
            {
                SubjectId = id;
            }

            var subject = await _viewModel.GetSubject(SubjectId);

            if (subject != null)
            {
                nameOfSub.Text = subject.subjectName;
                descOfSub.Text = subject.subjectDescription;
                nameOfLect.Text = subject.lecturer_name;
                emailOfLect.Text = subject.lecturer_email;
            }

            foreach (var enrollment in subject.enrollments)
            {
                if (enrollment.enrollment_id != 0)
                {
                    var studentCard = new Components.StudentCard
                    {
                        BindingContext = enrollment
                    };
                    studentStackLayout.Children.Add(studentCard);
                }
                else
                {
                    var image = new Image
                    {
                        Source = "nostudents.png",
                        Aspect = Aspect.AspectFit,
                        WidthRequest = 700,
                        HeightRequest = 700,
                    };
                    studentStackLayout.Children.Add(image);
                }
            }
        }
    }

    private async void DeleteSubject(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Delete Subject", "Are you sure you want to delete this subject?", "Yes", "No");

        if (answer)
        {
            await _viewModel.DeleteSubject(SubjectId);
            await DisplayAlert("Success!", "Subject deleted successfully.", "OK");
            _ = Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Oops!", "The subject was not deleted.", "OK");
        }
    }
}
