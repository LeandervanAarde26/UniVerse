using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Controls.RadialBarChart;
using UniVerse.Models;
using UniVerse.Services.StaffService;
using static UniVerse.Models.LecturerOverviewModel;

namespace UniVerse.ViewModels
{
    public class StaffViewModel: BaseViewModel
    {
        public StaffService _staffService;

        private ObservableCollection<Person> _allStaffList = new ObservableCollection<Person>();
        public ObservableCollection<Person> AllStaffList
        {
            get { return _allStaffList; }
            set
            {
                _allStaffList = value;
                OnPropertyChanged(nameof(AllStaffList));
            }
        }

        public ObservableCollection<Person> Lecturers { get; set; }

        public ObservableCollection<LecturerWithCourses> StaffMember { get; set; }
        public ObservableCollection<ChartEntry> StaffChart { get; set; }

        public string _nameEntry = string.Empty;
        public string NameEntry
        {
            get { return _nameEntry; }
            set
            {
                _nameEntry = value;
                OnPropertyChanged(nameof(NameEntry));
            }
        }

        public string _surnameEntry = string.Empty;
        public string SurnameEntry
        {
            get { return _surnameEntry; }
            set
            {
                _surnameEntry = value;
                OnPropertyChanged(nameof(SurnameEntry));
            }
        }

        public string _identifier = string.Empty;
        public string Identifier
        {
            get { return _identifier; }
            set
            {
                _identifier = value;
                OnPropertyChanged(nameof(Identifier));
            }
        }

        public string _emailEntry = string.Empty;
        public string EmailEntry
        {
            get { return _emailEntry; }
            set
            {
                _emailEntry = value;
                OnPropertyChanged(nameof(EmailEntry));
            }
        }

        public string _number = string.Empty;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public int _role_Input;
        public int RoleInput
        {
            get { return _role_Input; }
            set
            {
                _role_Input = value;
                OnPropertyChanged(nameof(RoleInput));
            }
        }

        public StaffViewModel(StaffService staffService)
        {
            _staffService = staffService;
            AllStaffList = new ObservableCollection<Person>();
            StaffMember = new ObservableCollection<LecturerWithCourses>();
            StaffChart = new ObservableCollection<ChartEntry>();
            NameEntry = String.Empty;
            EmailEntry = String.Empty;
            Number = String.Empty;
            Identifier = String.Empty;
            SurnameEntry = String.Empty;
            Lecturers = new ObservableCollection<Person>();
        }

        // Getting all the staffmembers to display
        public async Task GetAllStaffMembers()
        {
            var members = await _staffService.GetStaffMembersAsync();
            AllStaffList.Clear();
            var LecturerStaff = 0;
            var AdminStaff = 0;
            var maximumChartValue = 0;


            foreach (var member in members)
            {
                AllStaffList.Add(member);
                maximumChartValue++;

                if (member.role == "Lecturer")
                {
                    LecturerStaff++;
                }
                else
                {
                    AdminStaff++;
                }
            }
            double LecturerPerecent = Math.Round((double)LecturerStaff / (double)maximumChartValue * 100, 1);
            StaffChart.Add(new ChartEntry
            {
                Value = LecturerPerecent,
                Color = Color.FromArgb("#6023FF"),
                Text = "Visual Studio Code"
            });

            StaffChart.ToArray();
        }

        // Getting a single staffmember
        public async Task<LecturerWithCourses> GetStaffMember(int id)
        {
            var member = await _staffService.GetLecturerByIdAsync(id);
            StaffMember.Add(member);
            return member;
        }

        public async Task<AddpersonModel> AddStaff()
        {

            int userRole = RoleInput == 1 ? 1 : 2;

            AddpersonModel person = new()
            {
                person_id = 0,
                person_system_identifier = Identifier,
                first_name = NameEntry,
                last_name = SurnameEntry,
                person_email = EmailEntry,
                added_date = DateTime.UtcNow,
                person_active = true,
                role = userRole,
                person_image = "None",
                person_credits = 0,
                person_cell = Number,
                needed_credits = 0,
                person_password = "password",
            };

            var newMember = await _staffService.AddStaffAsync(person);

            Person newStaffMember = new Person()
            {
                id = newMember.person_id,
                person_system_identifier = newMember.person_system_identifier,
                name = $"{newMember.first_name} {newMember.last_name}",
                email = newMember.person_email,
                role = newMember.role == 1 ? "Admin" : "Lecturer",
                person_credits = newMember.person_credits,
                needed_credits = newMember.needed_credits,
                is_active = newMember.person_active
            };

            //AllStaffList.Add(newStaffMember);
            AllStaffList.Clear();

            await GetAllStaffMembers();

            NameEntry = String.Empty;
            EmailEntry = String.Empty;
            Number = String.Empty;
            Identifier = String.Empty;
            SurnameEntry = String.Empty;

            return person;
        }

        //Getting all the lecturerers
        public async Task GetAllLecturers()
        {
            var members = await _staffService.GetLecturersAsync();
            Lecturers.Clear();

            foreach (var member in members)
            {
                Lecturers.Add(member);
            }
        }
    }
}
