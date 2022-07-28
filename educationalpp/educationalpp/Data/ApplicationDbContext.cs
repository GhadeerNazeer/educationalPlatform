using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using educationalpp.Models;
using educationalpp.viewmodel;

namespace educationalpp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         
        public DbSet<student> student { get; set; }
        public DbSet<teacher> teacher { get; set; }

        public DbSet<department> department { get; set; }
        public DbSet<course> course { get; set; }
        public DbSet<course_student> courses_and_student { get; set; }
        public DbSet<courseviewmodel> courseviewmodel { get; set; }
        public DbSet<educationalpp.viewmodel.coursestudentmodel>? coursestudentmodel { get; set; }
    }
}