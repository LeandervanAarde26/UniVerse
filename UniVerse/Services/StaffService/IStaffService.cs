using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using static UniVerse.Models.LecturerOverviewModel;
namespace UniVerse.Services.StaffService
{
    public interface IStaffService
    {
        Task<List<Person>> GetStaffMembersAsync();
        Task<LecturerWithCourses> GetLecturerByIdAsync(int id);
        Task<AddpersonModel> AddStaffAsync(AddpersonModel staff);
        Task<List<Person>> GetLecturersAsync();
    }
}
