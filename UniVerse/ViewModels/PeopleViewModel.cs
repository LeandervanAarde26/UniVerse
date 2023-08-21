using System.Collections.ObjectModel;
using System.Diagnostics;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {

        //I do have shorter code for this but Ijust need to test it out first
        public RestService _restService;

        public ObservableCollection<PersonModel> PeopleList { get; set; }

        public PeopleViewModel(RestService restService)
        {
            _restService = restService;
            PeopleList = new ObservableCollection<PersonModel>();
        }

        //Get All Staff Members
        public async Task GetAllStaffMembers()
        {
            var StaffMembers = await _restService.RefreshDataAsync();
            PeopleList.Clear();

            foreach (var StaffMember in StaffMembers)
            {
                PeopleList.Add(StaffMember);
                Debug.WriteLine(StaffMember.email);
            }
        }

        //Get All Students
        public async Task GetAllStudents()
        {
            var Students = await _restService.RefreshDataAsync();
            PeopleList.Clear();

            foreach (var Student in Students)
            {
                PeopleList.Add(Student);
                Debug.WriteLine(Student.email);
            }
        }
    }
}
