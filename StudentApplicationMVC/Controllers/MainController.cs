using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register()
        {
            if (TempData["Username"] != null)
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("LogInID,Username,Password,AccessLevel")] LogIn logIn)
        {
           if(ModelState.IsValid)
            {
               context.Add(logIn);
                await context.SaveChangesAsync();
              return  RedirectToAction("LogIn", "Main");
            }
            return View(logIn);
        }
        public async Task<IActionResult> Index(string SearchTerm)
        {
            var search = await context.addUnitDetails.Where(m => m.UnitCode.Contains(SearchTerm) || m.UnitTitle.Contains(SearchTerm)).ToListAsync();
            if(string.IsNullOrEmpty(SearchTerm))
            {
         
           return View(await context.addUnitDetails.ToListAsync());
            }
            return View(search);
        }
        public IActionResult AddUnit()
        {
            if (TempData["AccessLevel"].ToString() != "Admin")
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnit([Bind("AddUnitDetailsID,UnitTitle,UnitCode,Assignment1,Assignment2,Exam,IformFile")] AddUnitDetails addUnit)
        {

            if (ModelState.IsValid)
            {

                var httpPath = webRoot.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(addUnit.IformFile.FileName);
                string extention = Path.GetExtension(addUnit.IformFile.FileName);
                addUnit.UnitOutline = filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(httpPath + "/UnitOutline", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await addUnit.IformFile.CopyToAsync(filestream);
                }
                context.Add(addUnit);
                await context.SaveChangesAsync();
               return RedirectToAction("Index", "Main");
            }
            return View(addUnit);
        }
        /// <summary>
        /// <c>Get Detials about a unit</c>
        /// </summary>
        /// <param name="id"><c>the unit code for the unit</c></param>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> GetUnitDetials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var unitcode = await context.addUnitDetails.FirstOrDefaultAsync(m => m.AddUnitDetailsID == id);
            if (unitcode == null)
            {
                return NotFound();
            }
            return View(unitcode);
        }
        public IActionResult LogIn()
        {
            if(TempData["Username"]!=null)
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Username,string Password)
        {
           if(Username==""||Password=="")
            {
                return NotFound();
            }
           var check= await context.LogIn.FirstOrDefaultAsync(m=>m.Username==Username&&m.Password==Password);
            if(check==null)
            {
                return View();
            }
            else
            {
           
                TempData["Username"] = check.Username;
                TempData["ID"] = check.LogInID;
                if (check.AccessLevel == "Admin")
                {
                    TempData["AccessLevel"] = check.AccessLevel;
                }
                TempData.Keep("Username");
                TempData.Keep("AccessLevel");
                return RedirectToAction("Index", "Main");
            }
        
        }
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Main");
        }

        public async Task<IActionResult> ViewProfile(int? id)
        {
           if(id==null)
            {
                return NotFound();
            }
            var username = await context.LogIn.FirstOrDefaultAsync(m => m.LogInID == id);
            if(username==null)
            {
                return NotFound();
            }
            return View(username);
        }
    }
}
