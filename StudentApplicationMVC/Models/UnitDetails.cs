using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplicationMVC.Models
{
    public class UnitDetails
    {
        public int UnitDetailsID { get; set; }
        [Required(ErrorMessage = "Please enter unit title")]
        public string UnitTitle { get; set; }
        [Required(ErrorMessage = "Please enter unit code")]
        public string UnitCode { get; set; }
        [Required(ErrorMessage = "Please enter unit campus")]
        public string Campus { get; set; }
       

        public virtual Teachers Teachers { get; set; }

        public int TeachersID { get; set; }

        public virtual ICollection<StudentGrades> Grades { get; set; }

    }
}
