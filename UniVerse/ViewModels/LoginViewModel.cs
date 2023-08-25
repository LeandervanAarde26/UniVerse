using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
      public RestService _restServive;
      private INavigation _navigation;

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

        public AuthenticatedUser _authUser = new AuthenticatedUser();
        public AuthenticatedUser AuthUser
        {
            get { return _authUser; }
            set
            {
                _authUser = value;
                OnPropertyChanged(nameof(AuthUser));
            }
        }

        public LoginViewModel(RestService restService, INavigation navigation){
            _restServive = restService;
            _navigation = navigation;
        }

        public async Task AuthenticatedStream()
        {
            try
            {
                AuthUser = await _restServive.PostDataAsync(EmailEntry, PasswordEntry);
                if(AuthUser != null)
                {
                    Debug.WriteLine(AuthUser.userEmail);
                    EmailEntry = String.Empty;
                    PasswordEntry = String.Empty;
                    await _navigation.PushAsync(new AppShell());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void CaptureInputValues()
        {
            Debug.WriteLine(EmailEntry);
            Debug.WriteLine(PasswordEntry);
        }
    }
}
