using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class AdminFeesViewModel : BaseViewModel
    {
        public RestService _restService;

        public ObservableCollection<AdminFees> AdminList { get; set; }

        public AdminFeesViewModel(RestService restService) 
        {
            _restService = restService;
            AdminList = new ObservableCollection<AdminFees>();
        }


        // Get Fees
        public async Task GetAdminAllFees()
        {
            var fees = await _restService.GetAdminFeesAsync();
            AdminList.Clear();

            foreach (var fee in fees)
            {
                AdminList.Add(fee);
                Debug.WriteLine($"Fees: {fee}");

            }

        }

        public async Task PayAdmins()
        {
            await _restService.PayAdmins();
        }
    }
}
