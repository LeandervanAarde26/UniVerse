using CommunityToolkit.Maui.Views;
using System;
using System.Diagnostics;
using UniVerse.Models;
using UniVerse.ViewModels;

namespace MauiToolkitPopupSample
{
    public partial class PopupDashboard : Popup
    {
        private PasswordChangeViewModel viewModel;

        private LoginViewModel loginViewModel;

        public string Email;
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public PopupDashboard()
        {
            InitializeComponent();
            Email = LoginViewModel.AuthUser.userEmail;
            Debug.WriteLine(Email);
            //BindingContext = this;

            viewModel = new PasswordChangeViewModel(new UniVerse.Services.RestService());
            BindingContext = viewModel;
        }

        public void Test(object sender, EventArgs e)
        {
            Debug.WriteLine("Testting");
        }

        //public async void ChangePasswordTester(object sender, EventArgs e)
        //{
        //    //string email = Email;
        //    //string password = viewModel.Password;

        //    var data = new PasswordModel
        //    {
        //        email = Email,
        //        password = viewModel.Password,
        //    };

        //    await viewModel.ChangePassword(data);

       
        //}


        //public async void ChangeThePassword(object sender, EventArgs e)
        //{
        //    string email = Email;
        //    string password = viewModel._passwordEntry;

        //    Debug.WriteLine(email);
        //    Debug.WriteLine(password);

        //    //var data = new PasswordModel
        //    //{
        //    //    email = email,
        //    //    password = password,
        //    //};

        //    //await viewModel.ChangePassword(data);

        //    //Email = "";
        //    //Password = "";

        //}
    }
}
