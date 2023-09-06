using System.ComponentModel;
using System.Diagnostics;
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

    private string _subjectName;
    public string SubjectName
    {
        get { return _subjectName; }
        set
        {
            if (_subjectName != value)
            {
                _subjectName = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectCode;
    public string SubjectCode
    {
        get { return _subjectCode; }
        set
        {
            if (_subjectCode != value)
            {
                _subjectCode = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectCost;
    public string SubjectCost
    {
        get { return _subjectCost; }
        set
        {
            if (_subjectCost != value)
            {
                _subjectCost = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectCredits;
    public string SubjectCredits
    {
        get { return _subjectCredits; }
        set
        {
            if (_subjectCredits != value)
            {
                _subjectCredits = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectColor;
    public string SubjectColor
    {
        get { return _subjectColor; }
        set
        {
            if (_subjectColor != value)
            {
                _subjectColor = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectRuntime;
    public string SubjectRuntime
    {
        get { return _subjectRuntime; }
        set
        {
            if (_subjectRuntime != value)
            {
                _subjectRuntime = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectDescription;
    public string SubjectDescription
    {
        get { return _subjectDescription; }
        set
        {
            if (_subjectDescription != value)
            {
                _subjectDescription = value;
                OnPropertyChanged();
            }
        }
    }

    private string _subjectClassAmount;
    public string SubjectClassAmount
    {
        get { return _subjectClassAmount; }
        set
        {
            if (_subjectClassAmount != value)
            {
                _subjectClassAmount = value;
                OnPropertyChanged();
            }
        }
    }

    private DateTime _subjectStartDate;
    public DateTime SubjectStartDate
    {
        get { return _subjectStartDate; }
        set
        {
            if (_subjectStartDate != value)
            {
                _subjectStartDate = value;
                OnPropertyChanged();
            }
        }
    }

    public SubjectsScreen()
	{
		InitializeComponent();

        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
        viewModel = new SubjectViewModel(new Services.SubjectServices.SubjectService());
        peopleViewModel = new PeopleViewModel(new Services.RestService());

        course_start.Date = DateTime.Today;

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

    private async void addSubject(object sender, EventArgs e)
    {
        string subjectName = SubjectName;
        string subjectCode = SubjectCode;
        string subjectColor = SubjectColor;
        string subjectDescription = SubjectDescription;
        int selectedLecturerId = 0;
        DateTime subjectStartDate = course_start.Date.ToUniversalTime();

        _ = int.TryParse(SubjectCost, out int subjectCost);
        _ = int.TryParse(SubjectCredits, out int subjectCredits);
        _ = int.TryParse(SubjectRuntime, out int subjectRuntime);
        _ = int.TryParse(SubjectClassAmount, out int subjectClassAmount);

        if (picker.SelectedItem != null)
        {
            var selectedLecturer = (LecturerPickerItem)picker.SelectedItem;
            selectedLecturerId = selectedLecturer.Id;
        }

        var newSubject = new SubjectModel
        {
            subject_name = subjectName,
            subject_code = subjectCode,
            subject_description = subjectDescription,
            subject_cost = subjectCost,
            subject_color = subjectColor,
            lecturer_id = selectedLecturerId,
            subject_credits = subjectCredits,
            subject_class_runtiem = subjectRuntime,
            subject_class_amount = subjectClassAmount,
            course_start = subjectStartDate
        };

        await viewModel.SaveSubject(newSubject);

        SubjectName = "";
        SubjectCode = "";
        SubjectCost = "";
        SubjectCredits = "";
        SubjectColor = "";
        SubjectRuntime = "";
        SubjectDescription = "";
        SubjectClassAmount = "";
        SubjectStartDate = DateTime.Today;

        await viewModel.GetAllSubjects();
    }
}
