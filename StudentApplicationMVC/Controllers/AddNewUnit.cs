using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApplicationMVC.Models;
using System.Threading.Tasks;

namespace StudentApplicationMVC.Controllers
{
    public class AddNewUnit : Controller
    {
        private readonly ApplicationDataContext context;

        public AddNewUnit(ApplicationDataContext context)
        {
            this.context = context;
        }
     /// <summary>
     /// Method <c>Index</c> Shows a list of Units
     /// </summary>
     /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await context.addNewUnits.ToListAsync());
        }
        /// <summary>
        ///  <c>Displays View for Adding a new unit</c><
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUnit()
        {
            return View();
        }
        /// <summary>
        /// <c>AddUnitPost</c> Post method for addnew methods
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnit([Bind("AddNewUnitID,UnitTitle,UnitCode,Assignment1,Assignment2,Exam,IformFile")] AddNewUnit unit)
        {
            if (ModelState.IsValid)
            {
                context.Add(unit);
                await context.SaveChangesAsync();
                RedirectToAction("index", "Home");
            }
            return View(unit);
        }
        /// <summary>
        /// <c>Get Detials about a unit</c>
        /// </summary>
        /// <param name="id"><c>the unit code for the unit</c></param>
        /// <returns></returns>
        public async Task<IActionResult> GetUnitDetials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var unitcode = await context.addNewUnits.FirstOrDefaultAsync(m => m.AddNewUnitID == id);
            if (unitcode == null)
            {
                return NotFound();
            }
            return View(unitcode);
        }
    }
}
