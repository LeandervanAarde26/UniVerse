using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UniVerse.Models
{
    public class AddStaffModal
    {
        public int person_id { get; set; }
        public string person_system_identifier { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string person_email { get; set; }
        public DateTime added_date { get; set; }
        public bool person_active { get; set; }
        public int role { get; set; }
        public int person_credits { get; set; }
        public string person_cell { get; set; }
        public int needed_credits { get; set; }
        public string person_password { get; set; }
    }
}
