using System.Collections.ObjectModel;
using System.Diagnostics;
//using Javax.Security.Auth;
using UniVerse.Models;
using UniVerse.Services;
using UniVerse.Services.SubjectServices;

namespace UniVerse.ViewModels
{

    internal class SubjectViewModel : BaseViewModel
    {
        public SubjectService _restService;

        public ObservableCollection<SubjectWithEnrollments> SubjectList { get; set; }
        public ObservableCollection<SubjectWithEnrollments> Subject { get; set; }

        public SubjectViewModel(SubjectService restService)
        {
            _restService = restService;
            SubjectList = new ObservableCollection<SubjectWithEnrollments>();
            Subject = new ObservableCollection<SubjectWithEnrollments>();
        }

        // Get Subjects
        public async Task GetAllSubjects()
        {
            var subjects = await _restService.GetSubjectsAsync();
            SubjectList.Clear();

            foreach (var subject in subjects)
            {
                SubjectList.Add(subject);
                Debug.WriteLine(subject.subjectName);
            }
            Debug.WriteLine(SubjectList);
        }

        //Get subject by id
        public async Task<SubjectWithEnrollments> GetSubject(int id)
        {
            var subject = await _restService.GetSubjectByIdAsync(id);
            Subject.Clear();
            Subject.Add(subject);
            Debug.WriteLine(subject.subjectName);
            return subject;
        }
    }
}