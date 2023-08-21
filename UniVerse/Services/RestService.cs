using System;
using System.Diagnostics;
using System.Text.Json;
using UniVerse.Models;

namespace UniVerse.Services
{
	public class RestService : IRestService
	{
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Urls
        internal string peopleUrl = "https://localhost:7050/api/People";

        public List<PeopleModel> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<PeopleModel>> RefreshDataAsync()
        {
            Items = new List<PeopleModel>();

            Uri uri = new (string.Format(peopleUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<PeopleModel>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}

