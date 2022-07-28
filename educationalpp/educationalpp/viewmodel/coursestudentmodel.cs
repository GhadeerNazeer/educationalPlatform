using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace educationalpp.viewmodel
{
    [Keyless]
    public class coursestudentmodel
    {
        public int? Id { get; set; }
       
        public float mark { get; set; }
        public string student_status { get; set; }
        public float total_payment { get; set; }
 
        public int? studentid { get; set; }
        public virtual SelectList? student { get; set; }
        public int? courseid { get; set; } 
        public virtual SelectList? course { get; set; } 

    }
}
