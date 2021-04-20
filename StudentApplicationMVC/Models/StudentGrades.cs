using System.Collections.Generic;
using System.ComponentModel;

namespace StudentApplicationMVC.Models
{
   
    public class StudentGrades
    {
        public int StudentGradesID { get; set; }
        public int Assignment1 { get; set; }
        public int Assignment2 { get; set; }
        public int Exam { get; set; }
        public string Semester { get; set; }
        public virtual UnitDetails Units { get; set; }
        public int UnitDetailsID { get; set; }

    }
}
