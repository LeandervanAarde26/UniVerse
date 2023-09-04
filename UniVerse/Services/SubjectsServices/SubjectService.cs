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
    }
}