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
        public string subject_name { get; set; }
        public string subject_code { get; set; }
        public string subject_description { get; set; }
        public int subject_cost { get; set; }
        public string subject_color { get; set; }
        public int lecturer_id { get; set; }
        public int subject_credits { get; set; }
        public int subject_class_runtiem { get; set; }
        public int subject_class_amount { get; set; }
        public string subjectImage { get; set; }
    }
}

