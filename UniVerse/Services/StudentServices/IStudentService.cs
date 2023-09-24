using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;

namespace UniVerse.Services.StudentServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<SingleStudentWithCourses> GetStudentByIdAsync(int id);
        Task<AddpersonModel> AddStudentAsync(AddpersonModel student);
    }
}
