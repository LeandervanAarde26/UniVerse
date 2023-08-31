using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using UniVerse.Models;

namespace UniVerse.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        //base api URL 
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List<Person> People { get; private set; }

        public List<Person> Students { get; private set; }
        public List<Person> Staff { get; private set; }
        public AuthenticatedUser AuthenticatedUser { get; private set; }

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

            Uri uri = new(string.Format(baseURL + "People/Lecturers"));
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

        public async Task<Lecturer> GetLecturerByIdAsync(int id)
        {
            Lecturer Lect = new();
            Uri lecturerUri = new(string.Format(baseURL + "People/Lecturer/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(lecturerUri);

                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Lect = JsonSerializer.Deserialize<Lecturer>(content, _serializerOptions);
                    Debug.WriteLine($"Name: {Lect.name}");
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

        public async Task<List<Person>> GetStudentsAsync()
        {
            Students = new List<Person>();
            Uri uri = new(string.Format(baseURL + "People/Students"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Students = JsonSerializer.Deserialize<List<Person>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            Student Stu = new();
            Uri studentUri = new(string.Format(baseURL + "People/Lecturer/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(studentUri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Stu = JsonSerializer.Deserialize<Student>(content, _serializerOptions);
                    Debug.WriteLine($"Name: {Stu.name}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Stu;
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

    }
}