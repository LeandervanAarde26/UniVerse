using System.Collections.ObjectModel;
using System.Diagnostics;
using UniVerse.Models;
using UniVerse.Services;
using UniVerse.Services.SubjectServices;

namespace UniVerse.ViewModels
{

    internal class SubjectViewModel : BaseViewModel
    {
        public SubjectService _restService;

        public ObservableCollection<SubjectWithLecturerModel> SubjectList { get; set; }
        public ObservableCollection<SubjectModel> Subject { get; set; }

        public SubjectViewModel(SubjectService restService)
        {
            _restService = restService;
            SubjectList = new ObservableCollection<SubjectWithLecturerModel>();
            Subject = new ObservableCollection<SubjectModel>();
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

        //Get subject by id
        public async Task<SubjectModel> GetSubject(int id)
        {
            var subject = await _restService.GetSubjectByIdAsync(id);
            Subject.Clear();
            Subject.Add(subject);
            Debug.WriteLine(subject.subject_name);
            return subject;
        }

        //add Subject
        public async Task SaveSubject(SubjectModel subject)
        {
            try
            {
                await _restService.SaveTodoItemAsync(subject, isNewSubject: true);
                Debug.WriteLine("Subject successfully saved.");
                _ = GetAllSubjects();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}