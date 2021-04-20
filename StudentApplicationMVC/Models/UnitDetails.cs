using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplicationMVC.Models
{
    public class UnitDetails
    {
        public int UnitDetailsID { get; set; }
        public string UnitTitle { get; set; }
        public string UnitCode { get; set; }
        public string Campus { get; set; }
        public string Teacher { get; set; }
        public virtual ICollection<StudentGrades> Grades { get; set; }

    }
}
