using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UniVerse.Models;
using UniVerse.ViewModels;

namespace UniVerse.Screens;

public partial class SubjectsScreen : ContentPage
{
    private SubjectViewModel viewModel;
    private PeopleViewModel peopleViewModel;

    private List<LecturerPickerItem> _pickerItems;
    public List<LecturerPickerItem> PickerItems
    {
        get { return _pickerItems; }
        set
        {
            _pickerItems = value;
            OnPropertyChanged(nameof(PickerItems));
        }
    }

    public SubjectsScreen()
	{
		InitializeComponent();

        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
        viewModel = new SubjectViewModel(new Services.SubjectServices.SubjectService());
        peopleViewModel = new PeopleViewModel(new Services.RestService());

        PickerItems = new List<LecturerPickerItem>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await viewModel.GetAllSubjects();
        await peopleViewModel.GetAllStaffMembers();

        PickerItems = peopleViewModel.StaffList.Select(lecturer => new LecturerPickerItem
        {
            Id = lecturer.id,
            Name = lecturer.name
        }).ToList();

        foreach (var subject in viewModel.SubjectList)
        {
            var subjectCard = new Components.SubjectCard
            {
                BindingContext = subject.Subject
            };
            subjectStackLayout.Children.Add(subjectCard);
        }
    }
}
