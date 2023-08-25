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
    internal class PeopleViewModel: BaseViewModel
    {
        public RestService _restService;
        // All of myt observerd properties 

        public ObservableCollection<Person> StaffList { get; set; }
        public ObservableCollection<Person> StudentList { get; set; }

        public PeopleViewModel(RestService restService) //instance of the restservice goes here
        {
            _restService = restService;

            StaffList = new ObservableCollection<Person>();
            StudentList = new ObservableCollection<Person>();
        }

        // Get all staff
        public async Task GetAllStaffMembers()
        {
            var members = await _restService.LoadLecturersAsync();
            StaffList.Clear();

            foreach (var member in members)
            {
                StaffList.Add(member);
                Debug.WriteLine(member.email);
            }
        }

        public async Task GetAllStudents()
        {
            var members = await _restService.RefreshDataAsync();
            StudentList.Clear();

            foreach (var member in members)
            {
                StudentList.Add(member);
                Debug.WriteLine(member.email);

            }
        }
    }
}
