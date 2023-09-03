using UniVerse.Models;


namespace UniVerse.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<List<SubjectWithEnrollments>> GetSubjectsAsync();
    }
}