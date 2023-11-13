using System;
using UniVerse.Models;

namespace UniVerse.Services
{
    public interface IRestService
    {

        Task<AuthenticatedUser> PostDataAsync(string email, string password);
        Task<List<LecturerFees>> GetFeesAsync();
        Task<List<StudentFees>> GetStudentFeesAsync();
        Task<List<AdminFees>> GetAdminFeesAsync();
        Task ChangePasswordAsync(PasswordModel data);
        Task<AddpersonModel> AddStudentAsync(AddpersonModel person);
        Task DeletePersonAsync(int id);
        Task PayLecturerSalaries();
        Task PayAdmins();
        Task CollectFromStudents();
        Task UpdatePerson(int id);
        Task UpdateCellPhone(int id, string phoneNumber);
    }
}