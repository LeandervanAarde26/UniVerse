namespace UniVerse.Models
{
	public class PersonModel
	{
        public int person_id { get; set; }

        public string person_system_identifier { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string email { get; set; }

        public int role { get; set; }

        public int person_credits { get; set; }

        public int needed_credits { get; set; }
    }
}

