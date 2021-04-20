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
        public async Task<IActionResult> GetAllUnits(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return View(await context.UnitDetails.ToListAsync());
            }
            return View(context.UnitDetails.FirstOrDefaultAsync(m => m.UnitTitle.Contains(SearchTerm) || m.UnitCode.Contains(SearchTerm)||m.Teacher.Contains(SearchTerm)));
          
        }
        //Register page 
        public IActionResult Register()
        {
            if (TempData["Username"] != null)
            {
                return RedirectToAction("GetAllUnits", "Main");
            }
            return View();
        }
        //REgister page post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("StudentDetailsID,FirstName,LastName,Username,Credits,Password,StudentNumber,AccessLevel,FormFileImage")] StudentDetails studentDetails)
        {
           
            if (ModelState.IsValid)
            {
              
                string wwwpath = webRoot.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(studentDetails.FormFileImage.FileName);
                string extension = Path.GetExtension(studentDetails.FormFileImage.FileName);
                studentDetails.StudentPhoto = filename = filename + Guid.NewGuid() + extension;
                string path = Path.Combine(wwwpath + "/ApplicationImages/StudentImage", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await studentDetails.FormFileImage.CopyToAsync(fileStream);
                }
                if (studentDetails.Password == "ThisIsAnAdmin")
                {
                    studentDetails.AccessLevel = "Admin";
                }
                else
                {
                    studentDetails.AccessLevel = "Student";
                }
                studentDetails.Credits = 360;
                context.Add(studentDetails);
                await context.SaveChangesAsync();
                return RedirectToAction("LogIn", "Main");
            }
            return View(studentDetails);
        }
        public IActionResult AddUnit()
        {

            if (TempData["AccessLevel"].ToString() != "Admin")
            {
                return RedirectToAction("GetAllUnits", "Main");
            }
            return View();
        }
        //Add new unit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnit([Bind("AddUnitDetailsID,UnitTitle,UnitCode,Campus,Teacher,Grades")] UnitDetails addUnit)
        {

            if (ModelState.IsValid)
            {
                context.Add(addUnit);
                await context.SaveChangesAsync();
                return RedirectToAction("GetAllUnits", "Main");
            }
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
        //Log in view
        public IActionResult LogIn()
        {
            if (TempData["Username"] != null)
            {
                return RedirectToAction("GetAllUnits", "Main");
            }
            return View();
        }
        //Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Username, string Password)
        {
            if (Username == "" || Password == "")
            {
                return NotFound();
            }
            var check = await context.StudentDetails.FirstOrDefaultAsync(m => m.Username == Username && m.Password == Password);
            if (check == null)
            {
                return View();
            }
            else
            {

                TempData["Username"] = check.Username;
                TempData["ID"] = check.StudentDetailsID;
                if (check.AccessLevel == "Admin")
                {
                    TempData["AccessLevel"] = check.AccessLevel;
                }
                TempData.Keep("Username");
                TempData.Keep("AccessLevel");
                return RedirectToAction("GetAllUnits", "Main");
            }

        }

        //Log out
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("GetAllUnits", "Main");
        }


        //View user profile
        public async Task<IActionResult> ViewProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var username = await context.StudentDetails.FirstOrDefaultAsync(m => m.StudentDetailsID == id);
            if (username == null)
            {
                return NotFound();
            }
            return View(username);
        }
        //AddNewUnitGrade
        public IActionResult AddNewUnitGrade()
        {
            ViewData["UnitDetailsID"] = new SelectList(context.UnitDetails, "UnitDetailsID", "UnitTitle");

            return View();
        }
        //AddNewUnitGrade post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUnitGrade([Bind("StudentGradeID,FirstName,LastName,StudentID,StudentImage,Assignment1,Assignment2,Exam,Semester,UnitDetailsID")] StudentGrades grade)
        {
            if(ModelState.IsValid)
            {
                context.Add(grade);
                await context.SaveChangesAsync();
                return RedirectToAction("GetAllUnits", "Main");
            }
            ViewData["UnitDetailsID"] = new SelectList(context.UnitDetails, "UnitDetailsID", "UnitTitle", grade.StudentGradesID);
            return View(grade);
        }
    }
}