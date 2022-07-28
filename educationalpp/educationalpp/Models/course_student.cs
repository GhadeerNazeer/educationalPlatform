using Microsoft.EntityFrameworkCore;

namespace educationalpp.Models
{
   
    public class course_student 
    {
      
        public int Id { get; set; }
        public virtual student? student { get; set; }
        public virtual course? course { get; set; }
        public float mark { get; set; } 
        public string student_status { get; set; }
        public float total_payment { get; set; }

    }
}
