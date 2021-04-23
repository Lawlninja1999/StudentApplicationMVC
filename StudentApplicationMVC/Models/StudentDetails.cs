using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplicationMVC.Models
{
    public class StudentDetails
    {
       public int StudentDetailsID { get; set; }
        [Required(ErrorMessage = "Please enter student firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter student lastname")]
        public string LastName { get; set; }

        public string StudentPhoto { get; set; }
        [Required(ErrorMessage = "Please enter student username")]
        public string Username { get; set; }
     
        public int Credits { get; set; }
        [Required(ErrorMessage = "Please enter student password")]
        public string Password { get; set; }

        public int StudentNumber { get; set; }

        public string AccessLevel { get; set; }
        [NotMapped,Required(ErrorMessage ="Please enter student image")]
        public IFormFile FormFileImage { get; set; }
        public virtual ICollection<StudentGrades> Grades { get; set; }
    }
}
