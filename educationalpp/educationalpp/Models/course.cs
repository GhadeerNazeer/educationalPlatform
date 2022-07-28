using Microsoft.EntityFrameworkCore;

namespace educationalpp.Models
{
   
    public class course
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? start_date { get; set; }

        public string? end_date { get; set; } 
        public int hours { get; set; }
        public float? price { get; set; }
        public virtual teacher? teacher { get; set; }
        public  virtual department? department { get; set; } 

    }
}
