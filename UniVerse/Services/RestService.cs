using System.Diagnostics;
using System.Text.Json;
using UniVerse.Models;

namespace UniVerse.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

        //I do have shorter code for this but Ijust need to test it out first

        //baseApi
        internal string baseUrl = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List <PersonModel> People { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task <List<PersonModel>> RefreshDataAsync()
        {
            People = new List<PersonModel>();

            // Staff Req
            Uri StaffUri = new (string.Format(baseUrl + "People/Lecturers"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(StaffUri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    People = JsonSerializer.Deserialize<List<PersonModel>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            // Student Req
            Uri StudentsUri = new (string.Format(baseUrl + "People/Students"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(StudentsUri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    People = JsonSerializer.Deserialize<List<PersonModel>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return People;
        }
    }
}