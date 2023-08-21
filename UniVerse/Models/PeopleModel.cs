namespace UniVerse.Models
{
	public class PeopleModel
	{
        public class People
        {
            public int person_id { get; set; }

            public string person_system_identifier { get; set; } = string.Empty;

            public string first_name { get; set; } = string.Empty;

            public string last_name { get; set; } = string.Empty;

            public string person_email { get; set; } = string.Empty;

            public DateTime added_date { get; set; } = DateTime.Now;

            public bool person_active { get; set; } = false;

            public int role { get; set; } = 3;

            public string person_image = string.Empty;

            public int person_credits { get; set; }

            public int needed_credits { get; set; }

            public string person_password { get; set; }

        }
    }
}

