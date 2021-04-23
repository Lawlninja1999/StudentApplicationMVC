using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApplicationMVC.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDataContext context;
        private readonly IWebHostEnvironment webRoot;

        public MainController(ApplicationDataContext context, IWebHostEnvironment webRoot)
        {
            this.context = context;
            this.webRoot = webRoot;
        }
        //REturn list of units
        public async Task<IActionResult> HomeScreen(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
              var ls= context.UnitDetails.Include(m => m.Teachers);
                return View(await ls.ToListAsync());
            }

            var Search = await context.UnitDetails.Where(m => m.UnitTitle.Contains(SearchTerm) ||
            m.UnitCode.Contains(SearchTerm) || m.Campus.Contains(SearchTerm)).ToListAsync();
            if (Search == null)
            {
                return View(await context.UnitDetails.Include(m => m.Teachers).ToListAsync());
            }
            return View(Search);

        }
        public IActionResult AddUnit()
        {

      
            ViewData["Teache"] = new SelectList(context.Teachers, "TeachersID", "TeacherNumber");
            return View();
        }
        //Add new unit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnit([Bind("AddUnitDetailsID,UnitTitle,UnitCode,Campus,TeachersID")] UnitDetails addUnit)
        {

            if (ModelState.IsValid)
            {

                context.Add(addUnit);
                await context.SaveChangesAsync();
                return RedirectToAction("HomeScreen", "Main");
            }
            ViewData["Teache"] = new SelectList(context.Teachers, "TeachersID", "TeacherNumber", addUnit.UnitDetailsID);
            return View(addUnit);
        }
        //View unit in more details
        public async Task<IActionResult> GetUnitDetials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var unitcode = await context.UnitDetails.FirstOrDefaultAsync(m => m.UnitDetailsID == id);
           
            if (unitcode == null)
            {
                return NotFound();
            }
            return View(unitcode);
        }


        //Log out
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("HomeScreen", "Main");
        }



        //AddNewUnitGrade
        public IActionResult AddNewUnitGrade()
        {
            ViewData["UnitDetails"] = new SelectList(context.UnitDetails, "UnitDetailsID", "UnitTitle");
            ViewData["Student"] = new SelectList(context.StudentDetails, "StudentDetailsID", "Username");

            return View();
        }
        //AddNewUnitGrade post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUnitGrade([Bind("StudentGradeID,Assignment1,Assignment2,Exam,Semester,UnitDetailsID,StudentDetailsID")] StudentGrades grade)
        {
            if(ModelState.IsValid)
            {
                context.Add(grade);
                await context.SaveChangesAsync();
                return RedirectToAction("HomeScreen", "Main");
            }
            ViewData["Student"] = new SelectList(context.StudentDetails, "StudentDetailsID", "Username", grade.StudentGradesID);
            ViewData["UnitDetails"] = new SelectList(context.UnitDetails, "UnitDetailsID", "UnitTitle", grade.StudentGradesID);
            return View(grade);
        }

        //Log in view
        public IActionResult LogInPortal()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInPortal(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return NotFound();
            }
            var Teacher = await context.Teachers.Where(m => m.Username == Username && m.Password == Password).FirstOrDefaultAsync();
            var Student = await context.StudentDetails.Where(m => m.Username == Username && m.Password == Password).FirstOrDefaultAsync();
            if (Teacher != null)
            {
                TempData["Teacher"] = Teacher.Username;
                TempData["AccessLevel"] = Teacher.AccessLevel;
                TempData["ID"] = Teacher.TeachersID;

                return RedirectToAction("HomeScreen", "Main");
            }
      
            else if(Student != null)
            {
                TempData["Student"] = Student.Username;
                TempData["MD"] = Student.StudentDetailsID;
                TempData.Keep("Username");
              
                return RedirectToAction("HomeScreen", "Main");
            }
            else
            {
             
                return View();

            }

        }

    }
}