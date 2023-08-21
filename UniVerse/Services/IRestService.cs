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
    public interface IRestService
    {
        Task<List<Person>> RefreshDataAsync();
    }
}
