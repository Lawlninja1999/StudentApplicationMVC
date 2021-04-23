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
    public class StudentsController : Controller
    {
        private readonly ApplicationDataContext context;
        private readonly IWebHostEnvironment webHost;

        public StudentsController(ApplicationDataContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public IActionResult LogNewStudent()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LogNewStudent([Bind("StudentDetailsID,FirstName,LastName,Username,Credits,Password,StudentNumber,AccessLevel,FormFileImage")] StudentDetails student)
        {
            var ass = await context.StudentDetails.FirstOrDefaultAsync(m => m.Username == student.Username);
            if (ass != null)
            {
                return RedirectToAction("LogInPortal", "Main");
            }
            if (ModelState.IsValid)
            {
                string webroot = webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(student.FormFileImage.FileName);
                string etc = Path.GetExtension(student.FormFileImage.FileName);
                student.StudentPhoto = filename = filename + Guid.NewGuid() + etc;
                string path = Path.Combine(webroot + "/ApplicationImages/StudentImage", filename);
               using(var filestream= new FileStream(path, FileMode.Create))
                {
                    await student.FormFileImage.CopyToAsync(filestream);
                }
                student.AccessLevel = "Student";
                student.Credits = 360;

                student.StudentNumber = new Random().Next(1000000, 2000000);

                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction("LogInPortal", "Main");
            }
            return View(student);
        }
       
        public async Task<IActionResult> UserProfile(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var usernam = await context.StudentDetails.FirstOrDefaultAsync(m => m.StudentDetailsID == id);
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
