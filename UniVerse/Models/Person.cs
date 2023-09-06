using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerse.Models
{
    public class Person
    {
        public int id { get; set; }

        public string person_system_identifier { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string role { get; set; }

        public int person_credits { get; set; }

        public int needed_credits { get; set; }
        public bool is_active { get; set; }
    }
}
