namespace educationalpp.Models
{
    public class department
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public IList<course>? num { get; set; }


    }
}
