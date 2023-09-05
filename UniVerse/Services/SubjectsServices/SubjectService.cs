using System.Diagnostics;
using System.Text.Json;
using UniVerse.Models;
using UniVerse.Services.SubjectService;

namespace UniVerse.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        HttpClient _client;
        //base api URL 
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;

        public List<SubjectWithEnrollments> Subjects { get; private set; }

        public SubjectService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        //get subjects
        public async Task<List<SubjectWithEnrollments>> GetSubjectsAsync()
        {
            Subjects = new List<SubjectWithEnrollments>();
            Uri uri = new(string.Format(baseURL + "CourseEnrollments"));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Subjects = JsonSerializer.Deserialize<List<SubjectWithEnrollments>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Subjects;
        }

        //Get subjects by id
        public async Task<SubjectWithEnrollments> GetSubjectByIdAsync(int id)
        {
            SubjectWithEnrollments subject = new();
            Uri studentUri = new(string.Format(baseURL + "CourseEnrollments/subject/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(studentUri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    subject = JsonSerializer.Deserialize<SubjectWithEnrollments>(content, _serializerOptions);
                    Debug.WriteLine($"Name: {subject.subjectName}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return subject;
        }

        //Delete subject
        public async Task DeletePersonAsync(int id)
        {
            Uri uri = new(string.Format(baseURL + "Subjects/{0}", id));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tSubject successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        // Add new lecturer
        public async Task UpdateSubjectLecturerAsync(int subjectId, int newLecturerId)
        {
            try
            {
                var payload = new
                {
                    SubjectId = subjectId,
                    NewLecturerId = newLecturerId
                };

                string jsonPayload = JsonSerializer.Serialize(payload, _serializerOptions);

                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(baseURL + "Subjects/ChangeLecturer", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("PUT request was successful.");
                }
                else
                {
                    Debug.WriteLine($"PUT request failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"ERROR {ex.Message}");
            }
        }
    }
}