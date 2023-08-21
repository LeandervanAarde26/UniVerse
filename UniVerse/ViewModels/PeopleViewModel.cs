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
        public RestService _restServive;
        // All of myt observerd properties 

        public ObservableCollection<Person> PeopleList { get; set; }

        public PeopleViewModel(RestService restServive) //instance of the restservice goes here
        {
            _restServive = restServive;

            PeopleList = new ObservableCollection<Person>();
        }

        public async Task GetAllStaffMembers()
        {
            var members = await _restServive.RefreshDataAsync();
            PeopleList.Clear();

            foreach (var member in members)
            {
                PeopleList.Add(member);
                Debug.WriteLine(member.email);

            }


        }
    }
}
