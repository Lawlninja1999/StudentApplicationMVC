using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentApplicationMVC.Models
{
   
    public class StudentGrades
    {
        public int StudentGradesID { get; set; }

        [Required]
        public int Assignment1 { get; set; }
        [Required]
        public int Assignment2 { get; set; }
        [Required]
        public int Exam { get; set; }
        [Required,StringLength(2)]
        public string Semester { get; set; }
        


        public virtual UnitDetails Units { get; set; }
        public int UnitDetailsID { get; set; }
        public virtual StudentDetails Student { get; set; }
        public int StudentDetailsID { get; set; }

    }
}
