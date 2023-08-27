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
    internal class LoginViewModel : BaseViewModel
    {
      public RestService _restServive;
      private readonly INavigation _navigation;

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

        public string _authError = String.Empty;
        public string AuthError
        {
            get { return _authError; }
            set
            {
                _authError = value;
                OnPropertyChanged(nameof(AuthError));
            }
        }

        public AuthenticatedUser _authUser = new();
        public AuthenticatedUser AuthUser
        {
            get { return _authUser; }
            set
            {
                _authUser = value;
                OnPropertyChanged(nameof(AuthUser));
            }
        }

        public int _userId = 0;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
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
                    EmailEntry = String.Empty;
                    PasswordEntry = String.Empty;
                    //await _navigation.PushAsync(new AppShell());
                    App.Current.MainPage = new AppShell();
                    AuthError = String.Empty;
                    await SecureStorage.Default.SetAsync("userEmail", AuthUser.userEmail);
                    await SecureStorage.Default.SetAsync("username", AuthUser.username);
                }
                else
                {
                    // Authentication failed, set an error message
                    AuthError = "Authentication failed. Please check your credentials.";
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                AuthError = "Authentication failed. Please check your credentials.";
            }
         
        }




    }
}
