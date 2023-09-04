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
    internal class FeesViewModel : BaseViewModel
    {
        public RestService _restService;

        public ObservableCollection<Fees> FeesList { get; set; }

        public FeesViewModel(RestService restService) 
        {
            _restService = restService;
           FeesList = new ObservableCollection<Fees>();
        }


        // Get Fees
        public async Task GetAllFees()
        {
            var fees = await _restService.GetFeesAsync();
            FeesList.Clear();

            foreach (var fee in fees)
            {
                FeesList.Add(fee);
                Debug.WriteLine($"Fees: {fee}");

            }
        }

        
    }
}
