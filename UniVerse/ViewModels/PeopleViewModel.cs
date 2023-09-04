using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Controls.RadialBarChart;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class PeopleViewModel : BaseViewModel
    {
        public RestService _restService;
        // All of myt observerd properties 

        public ObservableCollection<Person> StaffList { get; set; }
        public ObservableCollection<Person> AllStaffList { get; set; }
        public ObservableCollection<Student> StudentList { get; set; }
        public ObservableCollection<Lecturer> StaffMember { get; set; }
        public ObservableCollection<Student> Student { get; set; }
        public ObservableCollection<ChartEntry> Chart { get; set; }
        public ObservableCollection<ChartEntry> StaffChart { get; set; }

        public PeopleViewModel(RestService restService) //instance of the restservice goes here
        {
            _restService = restService;
            StaffList = new ObservableCollection<Person>();
            StudentList = new ObservableCollection<Student>();
            StaffMember = new ObservableCollection<Lecturer>();
            Student = new ObservableCollection<Student>();
            Chart = new ObservableCollection<ChartEntry>();
            StaffChart = new ObservableCollection<ChartEntry>();
            AllStaffList = new ObservableCollection<Person>();
        }

        // Get Staff
        public async Task GetAllStaffMembers()
        {
            var members = await _restService.RefreshDataAsync();
            StaffList.Clear();

            foreach (var member in members)
            {
                StaffList.Add(member);
                Debug.WriteLine(member.role);
            }
        }

        //Get staff member by id
        public async Task<Lecturer> GetStaffMember(int id)
        {
            var member = await _restService.GetLecturerByIdAsync(id);
            StaffMember.Add(member);
            return member;
        }

        // Get Students
        public async Task GetAllStudents()
        {
            var members = await _restService.GetStudentsAsync();
            StudentList.Clear();

            foreach (var member in members)
            {
                StudentList.Add(member);
            }
        }

        //Get student member by id
        public async Task<Student> GetStudent(int id)
        {
            var student = await _restService.GetStudentByIdAsync(id);
            Student.Add(student);
            return student;
        }

        public async Task GetAllstudents()
        {
            var members = await _restService.GetStudentsAsync();
            StudentList.Clear();
            var DegreeStudents = 0;
            var DiplomaStudents = 0;
            var maximumChartValue = 0;


            foreach (var member in members)
            {
                StudentList.Add(member);
                Debug.WriteLine(member.name);
                maximumChartValue++;

                if(member.role == "Degree student")
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
                Text = "Visual Studio Code"
            });

            Chart.ToArray();
        }


        public async Task GetAllStaff()
        {
            var members = await _restService.GetStaffMembersAsync();
            AllStaffList.Clear();
            var LecturerStaff = 0;
            var AdminStaff = 0;
            var maximumChartValue = 0;


            foreach (var member in members)
            {
                AllStaffList.Add(member);
                Debug.WriteLine(member.name);
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
    }
}
