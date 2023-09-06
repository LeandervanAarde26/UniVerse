using UniVerse.Models;


namespace UniVerse.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<List<SubjectWithEnrollments>> GetSubjectsAsync();
        Task DeleteCourseEnrollmentsAsync(int id);
        Task SaveSubjectAsync(SubjectModel subject, bool isNewSubject = false);
        Task DeletePersonAsync(int id);
  

    }
}