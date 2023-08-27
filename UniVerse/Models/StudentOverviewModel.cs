using System;
namespace UniVerse.Models
{
    public class Student
    {
        public int id { get; set; }

        public string image { get; set; }

        //public string person_system_identifier { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string role { get; set; }

        public string person_credits { get; set; }

        public string needed_credits { get; set; }

        public string person_system_identifier { get; set; }
    }
}