using System;
using System.Collections.Generic;
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
        public ObservableCollection<Person> StudentList { get; set; }
        public ObservableCollection<Lecturer> StaffMember { get; set; }
        public ObservableCollection<Person> Student { get; set; }
        public ObservableCollection<ChartEntry> Chart { get; set; }
        
    


        public PeopleViewModel(RestService restService) //instance of the restservice goes here
        {
            _restService = restService;
            StaffList = new ObservableCollection<Person>();
            StudentList = new ObservableCollection<Person>();
            StaffMember = new ObservableCollection<Lecturer>();
            Student = new ObservableCollection<Person>();
            Chart = new ObservableCollection<ChartEntry>();
        }

        // Get Staff
        public async Task GetAllStaffMembers()
        {
            var members = await _restService.RefreshDataAsync();
            StaffList.Clear();

            foreach (var member in members)
            {
                StaffList.Add(member);
            }
        }

        //Get staff member by id
        public async Task GetStaffMember(int id)
        {
            var member = await _restService.GetLecturerByIdAsync(id);
            StaffMember.Add(member);
     
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
        public async Task GetStudent(int id)
        {
            var student = await _restService.GetStudentByIdAsync(id);
            Student.Add(student);
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
            Debug.WriteLine($"Students: {(double)DegreeStudents / (double)maximumChartValue * 100}");
            Debug.WriteLine($"Diploma students: {DiplomaStudents}");
            Debug.WriteLine($"Maximum value on Chart: {maximumChartValue}");
            double DegreePercent = Math.Round((double)DegreeStudents / (double)maximumChartValue * 100, 1);
            Chart.Add(new ChartEntry
            {
                Value = DegreePercent,
                Color = Color.FromArgb("#6023FF"),
                Text = "Visual Studio Code"
            });

            Chart.ToArray();

            Debug.WriteLine($"Degree Percent = {DegreePercent}, {Chart[0].Value}");
        }
    }
}
