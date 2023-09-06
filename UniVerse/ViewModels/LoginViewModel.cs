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
        public static AuthenticatedUser AuthUser;
        private readonly INavigation _navigation;

        public LoginViewModel(RestService restService)
        {
            _restServive = restService;
          
        }

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
        public async Task AuthenticatedStream()
        {
            try
            {
                var auth = await _restServive.PostDataAsync(EmailEntry, PasswordEntry);
                EmailEntry = String.Empty;
                PasswordEntry = String.Empty;
                AuthUser = auth;
                App.Current.MainPage = new AppShell();
                AuthError = String.Empty;

                await SecureStorage.Default.SetAsync("userEmail", auth.userEmail);
                await SecureStorage.Default.SetAsync("username", auth.username);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                AuthError = "Authentication failed. Please check your credentials.";
            }
        }
    }
}
