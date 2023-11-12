namespace UniVerse.Models
{
    public class SubjectPickerItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Override ToString to display the desired text in the Picker
        public override string ToString()
        {
            return Name;
        }
    }
}
