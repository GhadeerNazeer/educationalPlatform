using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace educationalpp.viewmodel
{
    [Keyless]
     public class courseviewmodel
    {  
        public int? id { get; set; }
        public string Name { get; set; }

        public int hours { get; set; } 
        public float? price { get; set; }
        public string? start_date { get; set; } 
        public string? end_date { get; set; }
        public int? teacherid { get; set; }
        public virtual SelectList? teacher { get; set; }
        public int? departmentid { get; set; }
        public virtual SelectList? department { get; set; }

    }
}
