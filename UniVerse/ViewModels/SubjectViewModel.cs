using System.Collections.ObjectModel;
using System.Diagnostics;
//using Javax.Security.Auth;
using UniVerse.Models;
using UniVerse.Services;
using UniVerse.Services.SubjectServices;

namespace UniVerse.ViewModels
{

    public class SubjectViewModel : BaseViewModel
    {
        public SubjectService _restService;

        public ObservableCollection<SubjectWithEnrollments> SubjectList { get; set; }
        public ObservableCollection<SubjectWithEnrollments> Subject { get; set; }

        public int subjectCount = 0;
        public int SubjectCount
        {
            get { return subjectCount; }
            set
            {
                subjectCount = value;
                OnPropertyChanged(nameof(SubjectCount));
            }
        }

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
            SubjectCount = subjects.Count;  

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

        // delete course enrolement
        public async Task DeleteCourseEnrollment(int id)
        {
            try
            {
                await _restService.DeleteCourseEnrollmentsAsync(id);

                var enrollmentToRemove = Subject.FirstOrDefault(subject =>
                    subject.enrollments.Any(enrollment => enrollment.enrollment_id == id));

                if (enrollmentToRemove != null)
                {
                    var enrollment = enrollmentToRemove.enrollments.FirstOrDefault(enrollment => enrollment.enrollment_id == id);

                    if (enrollment != null)
                    {
                        enrollmentToRemove.enrollments.Remove(enrollment);
                    }
                }

                _ = GetAllSubjects();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error deleting course enrollment: " + ex.Message);
            }
        }


        //add Subject
        public async Task SaveSubject(SubjectModel subject)
        {
            try
            {
                await _restService.SaveSubjectAsync(subject, isNewSubject: true);
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