using System;
namespace UniVerse.Models
{
	public class LecturerOverviewModel
	{
        public class SubjectEnrollments
        {
            public int subject_id { get; set; }
            public string subject_name { get; set; }
            public string subject_code { get; set; }
            public string subject_color { get; set; }
        }
    }
}

