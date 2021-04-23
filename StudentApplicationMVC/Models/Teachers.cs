using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Models
{
    public class Teachers
    {
        public int TeachersID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TeacherNumber { get; set; }
        public string AccessLevel { get; set; }
        public string TeacherPhoto { get; set; }
        [NotMapped]
        public IFormFile TeacherFormFile { get; set; }
        public virtual ICollection<UnitDetails> Units { get; set; }  
    }
}
