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
        Task<List<Fees>> GetFeesAsync();
    }
}