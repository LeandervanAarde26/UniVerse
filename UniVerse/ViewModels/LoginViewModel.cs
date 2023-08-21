using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
      public RestService _restServive;

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

        public string _passwordEntry = string.Empty;
        public string PasswordEntry
        {
            get { return _passwordEntry; }
            set
            {
                _passwordEntry = value;
                OnPropertyChanged(nameof(PasswordEntry));
            }
        }

        public LoginViewModel(){ }

        public void CaptureInputValues()
        {
            Debug.WriteLine(EmailEntry);
            Debug.WriteLine(PasswordEntry);

        }
    }
}
