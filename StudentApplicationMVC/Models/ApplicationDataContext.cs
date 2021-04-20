using Microsoft.EntityFrameworkCore;

namespace StudentApplicationMVC.Models
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
        public DbSet<UnitDetails> UnitDetails { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<StudentGrades> Grades { get; set; }
    }
}
