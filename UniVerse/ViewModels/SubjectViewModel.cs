using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services;

namespace UniVerse.ViewModels
{
    internal class SubjectViewModel : BaseViewModel
    {
        public RestService _restService;

        public ObservableCollection<SubjectWithLecturerModel> SubjectList { get; set; }

        public SubjectViewModel(RestService restService)
        {
            _restService = restService;
            SubjectList = new ObservableCollection<SubjectWithLecturerModel>();
        }

        // Get Subjects
        public async Task GetAllSubjects()
        {
            var subjects = await _restService.GetSubjectsAsync();
            SubjectList.Clear();

            foreach (var subject in subjects)
            {
                SubjectList.Add(subject);
            }
        }
    }
}