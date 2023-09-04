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
    internal class StudentFeesViewModel : BaseViewModel
    {
        public RestService _restService;

        public ObservableCollection<StudentFees> StudentList { get; set; }

        public StudentFeesViewModel(RestService restService) 
        {
            _restService = restService;
            StudentList = new ObservableCollection<StudentFees>();
        }


        // Get Fees
        public async Task GetStudentAllFees()
        {
            var fees = await _restService.GetStudentFeesAsync();
            StudentList.Clear();

            foreach (var fee in fees)
            {
                StudentList.Add(fee);
                Debug.WriteLine($"Fees: {fee}");

            }

            var test = StudentList;
        }

        
    }
}
