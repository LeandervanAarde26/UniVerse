using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Controls.RadialBarChart;
using UniVerse.Models;
using UniVerse.Services.StudentServices;

namespace UniVerse.ViewModels
{
   

    public class StudentViewModel: BaseViewModel
    {
        public StudentService _studentService;
        public ObservableCollection<Student> StudentList { get; set; }
        public ObservableCollection<ChartEntry> Chart { get; set; }
        public ObservableCollection<ChartEntry> SingleStudentChart { get; set; }
        public ObservableCollection<SingleStudentWithCourses> Student { get; set; }


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

        public StudentViewModel(StudentService studentService)
        {
            _studentService = studentService;
            StudentList = new ObservableCollection<Student>();
            Chart = new ObservableCollection<ChartEntry>();
            NameEntry = String.Empty;
            EmailEntry = String.Empty;
            Number = String.Empty;
            Identifier = String.Empty;
            SurnameEntry = String.Empty;
            SingleStudentChart = new ObservableCollection<ChartEntry>();
            Student = new ObservableCollection<SingleStudentWithCourses>();
        }

        public async Task GetAllstudents()
        {
            var members = await _studentService.GetStudentsAsync();
            StudentList.Clear();
            var DegreeStudents = 0;
            var DiplomaStudents = 0;
            var maximumChartValue = 0;

            foreach (var member in members)
            {
                StudentList.Add(member);
                maximumChartValue++;

                if (member.role == "Degree student")
                {
                    DegreeStudents++;
                }
                else
                {
                    DiplomaStudents++;
                }
            }
            double DegreePercent = Math.Round((double)DegreeStudents / (double)maximumChartValue * 100, 1);
            Chart.Add(new ChartEntry
            {
                Value = DegreePercent,
                Color = Color.FromArgb("#6023FF"),
                Text = ""
            });

            _ = Chart.ToArray();
        }

        public async Task<SingleStudentWithCourses> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            Student.Add(student);
            double studentCredits = Math.Round((double)student.person_credits / (double)student.needed_credits * 100, 1);
            SingleStudentChart.Add(new ChartEntry
            {
                Value = studentCredits,
                Color = Color.FromArgb("#6023FF"),
                Text = "Visual Studio Code"
            });

            Chart.ToArray();

            return student;
        }
        public async Task<AddpersonModel> AddStudent()
        {

            int userRole = RoleInput == 1 ? 3 : 4;

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
                needed_credits = userRole == 3 ? 180 : 75,
                person_password = "password",
            };


            var newStudent  = await _studentService.AddStudentAsync(person);

            Student newStudentEnrolled = new()
            {
                id = newStudent.person_id,
                image = "",
                name = newStudent.first_name + " " + newStudent.last_name,
                email = newStudent.person_email,
                role = newStudent.role == 3 ? "Degree Student" : "Diploma Student",
                person_credits = 0,
                person_system_identifier = newStudent.person_system_identifier,
                needed_credits = newStudent.role == 3 ? 180 : 75,
                is_active = true,
            };

            StudentList.Clear();
            await GetAllstudents();

            NameEntry = String.Empty;
            EmailEntry = String.Empty;
            Number = String.Empty;
            Identifier = String.Empty;
            SurnameEntry = String.Empty;

            return person;
        }
    }
}
