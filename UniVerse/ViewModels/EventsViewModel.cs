using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Services.EventsServices;

namespace UniVerse.ViewModels
{
    public class EventsViewModel: BaseViewModel
    {
        public EventsService _eventsService;

        public ObservableCollection<Events> EventsList { get; set; }

        public EventsViewModel(EventsService eventsService) {
            _eventsService = eventsService;
            EventsList = new ObservableCollection<Events>();


        }

        public async Task GetAllEvents()
        {
            var events = await _eventsService.GetEventsAsync();
            EventsList.Clear();
            foreach( var ev in events) {
                EventsList.Add(ev);
            }
        }
    }
}
