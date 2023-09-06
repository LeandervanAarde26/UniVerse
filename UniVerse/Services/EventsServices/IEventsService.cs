using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;

namespace UniVerse.Services.EventsServices
{
    public interface IEventsService
    {
        Task<List<Events>> GetEventsAsync();
    }
}
