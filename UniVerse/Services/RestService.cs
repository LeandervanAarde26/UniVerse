using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using UniVerse.Models;
using static UniVerse.Models.LecturerOverviewModel;

namespace UniVerse.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        //base api URL 
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List<Person> People { get; private set; }

        public List<Student> Students { get; private set; }
        public List<Person> Staff { get; private set; }
        public AuthenticatedUser AuthenticatedUser { get; private set; }

        public List<LecturerFees> LecturerFee { get; private set; }

        public List<StudentFees> StudentFee { get; private set; }

        public List<AdminFees> AdminFee { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Person>> RefreshDataAsync()
        {
            People = new List<Person>();

            Uri uri = new(string.Format(baseURL + "People/Staff"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    People = JsonSerializer.Deserialize<List<Person>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return People;
        }

        public async Task<LecturerWithCourses> GetLecturerByIdAsync(int id)
        {
            LecturerWithCourses Lect = new();
            Uri lecturerUri = new(string.Format(baseURL + "People/Lecturer/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(lecturerUri);

                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Lect = JsonSerializer.Deserialize<LecturerWithCourses>(content, _serializerOptions);
                    Debug.WriteLine($"Name: {Lect.lecturer_name}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Lect;
        }

        public async Task<List<Person>> GetStaffMembersAsync()
        {
            Staff = new List<Person>();
            Uri uri = new(string.Format(baseURL + "People/Staff"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Staff = JsonSerializer.Deserialize<List<Person>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Staff;
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

        // Could it be that the functions were not seperated? I think they has to be seperate. 
        public async Task<AuthenticatedUser> PostDataAsync(string email, string password)
        {
            AuthenticatedUser AuthenticatedUser = null;
            Uri uri = new(string.Format(baseURL + "People/auth"));
            var requestData = new
            {
                email,
                password
            };
 
            var json = JsonSerializer.Serialize(requestData, _serializerOptions);
            StringContent stringContent = new(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage res = await _client.PostAsync(uri, stringContent);
                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    AuthenticatedUser = JsonSerializer.Deserialize<AuthenticatedUser>(responseContent, _serializerOptions);
                }
                else
                {
                    throw new AuthenticationException("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new AuthenticationException("An error occurred during authentication.");
            }

            return AuthenticatedUser;
        }




        public async Task<List<LecturerFees>> GetFeesAsync()
        {
            LecturerFee = new List<LecturerFees>();
            Uri uri = new(string.Format(baseURL + "PaymentSummaries/lecturerfees"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    LecturerFee = JsonSerializer.Deserialize<List<LecturerFees>>(content, _serializerOptions);
                    Debug.WriteLine($"Lecturer: {LecturerFee}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return LecturerFee;
        }


        public async Task<List<StudentFees>> GetStudentFeesAsync()
        {
            StudentFee = new List<StudentFees>();
            Uri uri = new(string.Format(baseURL + "PaymentSummaries/studentFees"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    StudentFee = JsonSerializer.Deserialize<List<StudentFees>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return StudentFee;
        }



        public async Task<List<AdminFees>> GetAdminFeesAsync()
        {
            AdminFee = new List<AdminFees>();
            Uri uri = new(string.Format(baseURL + "PaymentSummaries/Adminfees"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    AdminFee = JsonSerializer.Deserialize<List<AdminFees>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return AdminFee;
        }



    }

}