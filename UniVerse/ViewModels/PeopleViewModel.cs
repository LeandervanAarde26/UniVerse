using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public PeopleViewModel(RestService restService) //instance of the restservice goes here
        {
            _restService = restService;
            StaffList = new ObservableCollection<Person>();
            StudentList = new ObservableCollection<Person>();
            StaffMember = new ObservableCollection<Lecturer>();
            Student = new ObservableCollection<Person>();
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
        public async Task GetStudent(int id)
        {
            var student = await _restService.GetStudentByIdAsync(id);
            Student.Add(student);
        }

        public async Task GetAllstudents()
        {
            var members = await _restService.GetStudentsAsync();
            StudentList.Clear();

            foreach (var member in members)
            {
                StudentList.Add(member);
                Debug.WriteLine(member.name);
            }
        }
    }
}
