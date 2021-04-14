using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Models
{
    public class ApplicationDataContext:DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options):base(options)
        {

        }
       public DbSet<AddNewUnit> addNewUnits { get; set; }
    }
}
