using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using UniVerse.Models;
using UniVerse.ViewModels;
using static UniVerse.Models.LecturerOverviewModel;

namespace UniVerse.Services.StaffService
{
    public class StaffService : IStaffService
    {
        HttpClient _client;
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List<Person> Staff { get; private set; }

        public StaffService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        // Staff page
        // Get all staff members
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

        //Get individual staff member admin/lecturers. 
        // Endpoint was originally only for one, but changed to be more inclusive. 
        public async Task<LecturerWithCourses> GetLecturerByIdAsync(int id)
        {
            LecturerWithCourses Lect = new();
            Uri lecturerUri = new(string.Format(baseURL + "People/Lecturer/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(lecturerUri);

                if (response.IsSuccessStatusCode)
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

        // Add new StaffMember to list

        public async Task<AddpersonModel> AddStaffAsync(AddpersonModel staff)
        {
            if (staff == null)
            {
                return null;
            }

            Uri uri = new(string.Format(baseURL + "People/PostPeople", String.Empty));

            AddpersonModel addStaff = null;
            AddpersonModel newPerson = new()
            {
                person_id = 0,
                person_system_identifier = staff.person_system_identifier,
                first_name = staff.first_name,
                last_name = staff.last_name,
                person_email = staff.person_email,
                added_date = DateTime.UtcNow,
                person_active = true,
                role = staff.role,
                person_image = "None",
                person_credits = 0,
                person_cell = staff.person_cell,
                needed_credits = 0,
                person_password = "admin",
            };

            var json = JsonSerializer.Serialize<AddpersonModel>(newPerson, _serializerOptions);
            StringContent content = new(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage res = await _client.PostAsync(uri, content);

                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    addStaff = JsonSerializer.Deserialize<AddpersonModel>(responseContent, _serializerOptions);

                    if (addStaff != null)
                    {
                        // Debug statement to log the values of addStaff properties
                        Debug.WriteLine($"addStaff.person_id: {addStaff.person_id}");

                        Person newStaffMember = new Person()
                        {
                            id = addStaff.person_id,
                            person_system_identifier = addStaff.person_system_identifier,
                            name = $"{addStaff.first_name} {addStaff.last_name}",
                            email = addStaff.person_email,
                            role = addStaff.role == 1 ? "Admin" : "Lecturer",
                            person_credits = addStaff.person_credits,
                            needed_credits = addStaff.needed_credits,
                            is_active = addStaff.person_active
                        };

                    }
                    else
                    {
                        Debug.WriteLine("addStaff is null");
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

            return addStaff;
        }

        //Get list of lecturerers
        public async Task<List<Person>> GetLecturersAsync()
        {
            Staff = new List<Person>();
            Uri uri = new(string.Format(baseURL + "People/Lecturers"));
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

    }
}
