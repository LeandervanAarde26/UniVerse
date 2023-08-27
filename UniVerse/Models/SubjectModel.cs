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
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectDescription { get; set; }
        public int SubjectCost { get; set; }
        public string SubjectColor { get; set; }
        public int LecturerId { get; set; }
        public int SubjectCredits { get; set; }
        public int SubjectClassRuntime { get; set; }
        public int SubjectClassAmount { get; set; }
        public string SubjectImage { get; set; }
    }

}

