namespace educationalpp.Models
{
    public class teacher
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int GenderId { get; set; }

        public string? Date_of_Birth { get; set; }
        public string? Date_of_employment { get; set; }
        public String address { get; set; }
        public string Phone { get; set; }

        public IList<course>? number_of_courses { get; set; }


    }
}
