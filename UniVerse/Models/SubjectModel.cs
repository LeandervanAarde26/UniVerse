using System;
namespace UniVerse.Models
{
    public class SubjectWithLecturerModel
    {
        public SubjectModel Subject { get; set; }
        public string LecturerName { get; set; }
    }

    public class SubjectModel
    {
        public int subject_id { get; set; }
        public string subject_name { get; set; } = String.Empty;
        public string subject_code { get; set; } = String.Empty;
        public string subject_description { get; set; } = String.Empty;
        public int subject_cost { get; set; } = 0;
        public string subject_color { get; set; } = String.Empty;
        public int lecturer_id { get; set; }
        public int subject_credits { get; set; } = 0;
        public int subject_class_runtiem { get; set; } = 0;
        public int subject_class_amount { get; set; } = 0;
        public string subjectImage { get; set; } = String.Empty;
        public bool is_active { get; set; }
        public DateTime course_start { get; set; } = DateTime.Now;
    }
}

