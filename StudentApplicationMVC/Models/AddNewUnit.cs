using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplicationMVC.Models
{
    public class AddNewUnit
    {
        public int AddNewUnitID { get; set; }

        [DisplayName("Unit Title")]
        public string UnitTitle { get; set; }
        [DisplayName("UnitCode")]
        public string UnitCode { get; set; }

        [DisplayName("Assignment 1 ")]
        public int Assignment1 { get; set; }

        [DisplayName("Assignment 2")]
        public int Assignment2 { get; set; }

        [DisplayName("Exam")]
        public int Exam { get; set; }

        [DisplayName("Upload Unit Outline")]
        [NotMapped]
        public IFormFile IformFile { get; set; }

        public string UnitOutline { get; set; }


    }
}
