using UniVerse.ViewModels;
using UniVerse.Models;
using System.Diagnostics;

namespace UniVerse.Components;

public partial class StudentCard : ContentView
{
    private readonly SubjectViewModel _viewModel;

    public StudentCard(SubjectViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this;
        _viewModel = viewModel;
    }

    private async void DeleteEnrolement(object sender, EventArgs e)
    {
        if (BindingContext is Enrollment enrollment)
        {
            int enrolementId = enrollment.enrollment_id;
            Debug.WriteLine(enrolementId);
            await _viewModel.DeleteCourseEnrollment(enrolementId);
        }
    }
}
