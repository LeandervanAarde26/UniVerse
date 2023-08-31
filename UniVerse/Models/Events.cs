using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerse.Models
{
    public class Events
    {
        public int event_id { get; set; }

        public string event_name { get; set; }

        public string event_description { get; set; }

        public string staff_organiser { get; set; }

        public string event_date { get; set; }
    }
}
