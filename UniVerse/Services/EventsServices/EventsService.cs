using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniVerse.Models;

namespace UniVerse.Services.EventsServices
{
    public class EventsService : IEventsService
    {
        HttpClient _client;
        //base api URL 
        internal string baseURL = "https://localhost:7050/api/";
        JsonSerializerOptions _serializerOptions;
        public List<Events> Events { get; private set; }
        public EventsService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<Events>> GetEventsAsync()
        {
            Events = new List<Events>();
            Uri uri = new(string.Format(baseURL + "Events"));

            try
            {
                HttpResponseMessage res = await _client.GetAsync(uri);
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Events = JsonSerializer.Deserialize<List<Events>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return Events;
        }
    }
}
