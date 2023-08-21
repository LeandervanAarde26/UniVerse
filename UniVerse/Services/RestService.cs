using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniVerse.Models;

namespace UniVerse.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

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

            Uri uri = new Uri(string.Format(baseUrl + "People/Lecturers"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
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