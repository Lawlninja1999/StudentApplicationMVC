using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDataContext context;
        private readonly IWebHostEnvironment iwebhost;

        public TeachersController(ApplicationDataContext context, IWebHostEnvironment iwebhost)
        {
            this.context = context;
            this.iwebhost = iwebhost;
        }
        public IActionResult LogNewTeacher()
        {
            if(TempData.ContainsKey("Username"))
            {
                return RedirectToAction("HomeScreen", "Main");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogNewTeacher([Bind("TeachersID,FirstName,LastName,,Username,Password,TeacherNumber,AccessLevel,TeacherFormFile")] Teachers teachers)
        {
            if(!teachers.Username.StartsWith("Staff"))
            {
                return View(teachers);
            }
            var ass= await context.Teachers.FirstOrDefaultAsync(m => m.Username == teachers.Username);
            if(ass!=null)
            {
                return RedirectToAction("LogInPortal", "Main");
            }
            if(ModelState.IsValid)
            {
               
                string webhot = iwebhost.WebRootPath;
                string file = Path.GetFileNameWithoutExtension(teachers.TeacherFormFile.FileName);
                string ext = Path.GetExtension(teachers.TeacherFormFile.FileName);
                teachers.TeacherPhoto = file = file + Guid.NewGuid() + ext;
                string path = Path.Combine(webhot + "/ApplicationImages/TeacherImage", file);
                using(var filestream= new FileStream(path,FileMode.Create))
                {
                    await teachers.TeacherFormFile.CopyToAsync(filestream);
                }
                teachers.AccessLevel = "Teacher";
                int num = new Random().Next(1000000, 2000000);
                teachers.TeacherNumber = num;
                context.Add(teachers);
                await context.SaveChangesAsync();
                return RedirectToAction("LogInPortal", "Main");

            }
            return View(teachers);
        }
        [HttpGet]
        public async Task<IActionResult> ViewProfile(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }
            var usernam = await context.Teachers.FirstOrDefaultAsync(m => m.TeachersID == id);
            if (usernam != null)
            {
                return View(usernam);
            }
            else
            {
                return RedirectToAction("HomeScreen", "Main");
            }

        }


    }
}
