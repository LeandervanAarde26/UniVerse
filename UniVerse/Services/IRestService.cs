using System;
using UniVerse.Models;

namespace UniVerse.Services
{
    public interface IRestService
    {
        Task<List<Person>> RefreshDataAsync();
        Task<List<Student>> GetStudentsAsync();
        Task<AuthenticatedUser> PostDataAsync(string email, string password);
        Task<List<Person>> GetStaffMembersAsync();
        Task<List<LecturerFees>> GetFeesAsync();
        Task<List<StudentFees>> GetStudentFeesAsync();
        Task<List<AdminFees>> GetAdminFeesAsync();
        Task<AddStaffModel> AddStaffAsync(string person_system_identifier, string first_name, string last_name, int role, string person_email, string person_cell);
    }
}