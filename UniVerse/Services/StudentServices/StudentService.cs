using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniVerse.Models;

namespace UniVerse.Services.StudentServices
{
    public class StudentService: IStudentService
    {
        HttpClient _client;
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List<Student> Students { get; set; }

        public StudentService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            Students = new List<Student>();
            Uri uri = new(string.Format(baseURL + "People/Students"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Students = JsonSerializer.Deserialize<List<Student>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Students;
        }

        public async Task<SingleStudentWithCourses> GetStudentByIdAsync(int id)
        {
            SingleStudentWithCourses Student = new();
            Uri studentUri = new(string.Format(baseURL + "People/student/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(studentUri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Student = JsonSerializer.Deserialize<SingleStudentWithCourses>(content, _serializerOptions);
                    Debug.WriteLine($"Name: {Student.student_name}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Student;
        }
        //Adding students.
        public async Task<AddpersonModel> AddStudentAsync(AddpersonModel student)
        {
            if (student == null)
            {
                return null;
            }
            Uri uri = new(string.Format(baseURL + "People/PostPeople", String.Empty));
            AddpersonModel addStudent = null;
            AddpersonModel newPerson = new()
            {
                person_id = 0,
                person_system_identifier = student.person_system_identifier,
                first_name = student.first_name,
                last_name = student.last_name,
                person_email = student.person_email,
                added_date = DateTime.UtcNow,
                person_active = true,
                role = student.role,
                person_image = "None",
                person_credits = 0,
                person_cell = student.person_cell,
                needed_credits = student.needed_credits,
                person_password = "password",
            };
            var json = JsonSerializer.Serialize<AddpersonModel>(newPerson, _serializerOptions);
            StringContent content = new(json, Encoding.UTF8, "application/json");

            try
            {

                HttpResponseMessage res = await _client.PostAsync(uri, content);

                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    addStudent = JsonSerializer.Deserialize<AddpersonModel>(responseContent, _serializerOptions);

                    if(addStudent != null)
                    {
                        Student newStudent = new()
                        {
                            id = addStudent.person_id,
                            image = addStudent.person_image,
                            name = addStudent.first_name + addStudent.last_name,
                            email = addStudent.person_email,
                            role = addStudent.role == 3 ? "Degree Student" : "Diploma Student",
                            person_credits = addStudent.person_credits,
                            needed_credits = addStudent.needed_credits,
                            person_system_identifier = addStudent.person_system_identifier,
                            is_active = addStudent.person_active
                        };

                        Students.Add(newStudent);
                    }
                }
                else
                {
                    Debug.WriteLine("Returned with unsuccessful response " + res);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return addStudent;
        }



    }
}
