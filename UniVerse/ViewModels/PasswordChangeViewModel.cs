using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class PasswordChangeViewModel : BaseViewModel
    {

       

        public RestService _restService;

        public ObservableCollection<PasswordModel> AdminList { get; set; }
        public string Password { get; set; }
        public ICommand OnChangePassword { get; }



        public PasswordChangeViewModel(RestService restService) 
        {
            _restService = restService;
            AdminList = new ObservableCollection<PasswordModel>();

            Password = string.Empty;
            OnChangePassword = new Command(async () =>  await ChangePassword() );
        }


        // Get Fees
        private async Task ChangePassword()
        {
            try
            {
                PasswordModel data = new()
                {
                    email = LoginViewModel.AuthUser.userEmail,
                    password = Password

                };
               
                await _restService.ChangePasswordAsync(data);
                Debug.WriteLine("Subject successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
        }


    }
}
