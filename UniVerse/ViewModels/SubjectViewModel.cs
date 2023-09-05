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

        //Delete Subject
        public async Task DeleteSubject(int id)
        {
            try
            {
                await _restService.DeletePersonAsync(id);
                var SubjectToRemove = SubjectList.FirstOrDefault(p => p.subjectId == id);
                if (SubjectToRemove != null)
                {
                    SubjectList.Remove(SubjectToRemove);
                }
                _ = GetAllSubjects();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error deleting person: " + ex.Message);
            }
        }

        // Update Subject Lecturer
        public async Task UpdateSubjectLecturer(int subjectId, int newLecturerId)
        {
            try
            {
                await _restService.UpdateSubjectLecturerAsync(subjectId, newLecturerId);
                _ = GetAllSubjects();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error updating subject lecturer: " + ex.Message);
            }
        }
    }
}