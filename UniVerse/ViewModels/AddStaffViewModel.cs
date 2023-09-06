using System.Collections.ObjectModel;
using System.Diagnostics;
//using Javax.Security.Auth;
using UniVerse.Models;
using UniVerse.Services;
using UniVerse.Services.SubjectServices;

namespace UniVerse.ViewModels
{

    internal class AddStaffViewModel : BaseViewModel
    {
        public RestService _restServive;
        public static AddStaffModel AddStaff;

        public AddStaffViewModel(RestService restService)
        {
            _restServive = restService;
        }

        public string _name = string.Empty;
        public string NameEntry
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(NameEntry));
            }
        }

        public string _surname = string.Empty;
        public string SurnameEntry
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(SurnameEntry));
            }
        }

        public string _number = string.Empty;
        public string NumberEntry
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(NumberEntry));
            }
        }

        public string _cell = string.Empty;
        public string CellEntry
        {
            get { return _cell; }
            set
            {
                _cell = value;
                OnPropertyChanged(nameof(CellEntry));
            }
        }



        //Picker Member Type

        private int _role;
        public int RoleEntry
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(RoleEntry));
            }
        }




        public string _email = string.Empty;
        public string EmailEntry
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(EmailEntry));
            }
        }






        public async Task AddNewStaff()
        {
            try
            {
                var add = await _restServive.AddStaffAsync(NumberEntry, NameEntry, SurnameEntry, RoleEntry, EmailEntry, CellEntry);
                Debug.WriteLine(NumberEntry);
                Debug.WriteLine(NameEntry);
                Debug.WriteLine(SurnameEntry);
                Debug.WriteLine(RoleEntry);
                //Debug.WriteLine(EmailEntry);
                Debug.WriteLine(CellEntry);

                NameEntry = String.Empty;
                SurnameEntry = String.Empty;
                CellEntry = String.Empty;
                NumberEntry = String.Empty;
                RoleEntry = 0;
                EmailEntry = String.Empty;
                AddStaff = add;


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}