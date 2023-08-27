using System;
using UniVerse.Models;

namespace UniVerse.Services
{
    public interface IRestService
    {
        Task<List<Person>> RefreshDataAsync();
        Task<List<Person>> GetStudentsAsync();
        Task<AuthenticatedUser> PostDataAsync(string email, string password);
    }
}