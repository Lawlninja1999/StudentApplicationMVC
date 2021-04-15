using Microsoft.EntityFrameworkCore;

namespace StudentApplicationMVC.Models
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
        public DbSet<AddUnitDetails> addUnitDetails { get; set; }
        public DbSet<LogIn> LogIn { get; set; }
    }
}
