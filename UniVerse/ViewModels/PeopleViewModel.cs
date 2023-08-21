using System.Collections.ObjectModel;
using System.Diagnostics;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        public RestService _restService;

        public ObservableCollection<PersonModel> PeopleList { get; set; }

        public PeopleViewModel(RestService restService)
        {
            _restService = restService;
            PeopleList = new ObservableCollection<PersonModel>();
        }

        public async Task GetAllStaffMembers()
        {
            var StaffMembers = await _restService.RefreshDataAsync();
            PeopleList.Clear();

            foreach (var StaffMember in StaffMembers)
            {
                PeopleList.Add(StaffMember);
                Debug.WriteLine(StaffMember.email); // Access email property of Person
            }
        }
    }
}
