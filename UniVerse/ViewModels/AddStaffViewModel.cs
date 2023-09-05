using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class AddStaffViewModel : BaseViewModel
    {
        public RestService _restServive;
        public static AddStaffModal AddStaff;

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
        public int _role = 0;
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
                _name = value;
                OnPropertyChanged(nameof(EmailEntry));
            }
        }






        public async Task AddNewStaff()
        {
            try
            {
                var add = await _restServive.AddStaffAsync(NumberEntry, NameEntry, SurnameEntry, RoleEntry, EmailEntry, CellEntry);


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
