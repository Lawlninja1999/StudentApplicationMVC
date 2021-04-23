using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Models
{
    public class Teachers
    {
        public int TeachersID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int TeacherNumber { get; set; }
        public string AccessLevel { get; set; }
        public string TeacherPhoto { get; set; }
        [NotMapped, Required]
        public IFormFile TeacherFormFile { get; set; }
        public virtual ICollection<UnitDetails> Units { get; set; }  
    }
}
