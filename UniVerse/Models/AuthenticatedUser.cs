using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerse.Models
{
    public class AuthenticatedUser
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string userEmail { get; set; }
    }
}
