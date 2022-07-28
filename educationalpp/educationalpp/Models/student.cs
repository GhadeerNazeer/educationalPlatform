namespace educationalpp.Models
{
    public class student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? Date_of_Birth { get; set; }

        public int GenderId { get; set; }
        public String Address { get; set; }

        public string Phone { get; set; }
        public IList<course_student>? num  { get; set; }
    }
}
