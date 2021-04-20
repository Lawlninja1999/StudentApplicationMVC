using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplicationMVC.Models
{
    public class StudentDetails
    {
       public int StudentDetailsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentPhoto { get; set; }
        public string Username { get; set; }
        public int Credits { get; set; }
        public string Password { get; set; }
        public int StudentNumber { get; set; }
        public string AccessLevel { get; set; }
        [NotMapped]
        public IFormFile FormFileImage { get; set; }
    }
}
