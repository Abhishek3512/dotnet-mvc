using DovetailSol.Data;
using DovetailSol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DovetailSol.Controllers
{
    public class EMPCRUDController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EMPCRUDController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Department()
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Department(string department)
        {
            ViewBag.Departments = GetDepartments();
            var employees = _context.EMP.Where(e => e.Department == department).ToList();
            return View(employees);
        }

        public IActionResult Designation()
        {
            ViewBag.Designations = GetDesignations();
            return View();
        }

        [HttpPost]
        public IActionResult Designation(string designation)
        {
            ViewBag.Designations = GetDesignations();
            var employees = _context.EMP.Where(e => e.Designation == designation).ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = GetDepartments();
            ViewBag.Designations = GetDesignations();
            return View(new EMP());
        }
        [HttpPost]
        public IActionResult Create(EMP employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = GetDepartments();
                ViewBag.Designations = GetDesignations();
                return View(employee); // Show errors if validation fails
            }

            try
            {
                _context.Add(employee); // Add to DB
                _context.SaveChanges(); // Commit changes
                TempData["Success"] = "Details Saved!";
                return RedirectToAction("Index", "Home"); // Redirect after saving
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error!" + ex.Message;
                return View(employee);
            }
        }
        private List<string> GetDepartments()
        {
            return new List<string> { "HR", "IT", "Finance", "Sales", "Other" };
        }
        private List<string> GetDesignations()
        {
            return new List<string> { "Intern", "Manager", "Developer", "Other" };
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.EMP.Find(id);
            if (employee == null) return NotFound();

            ViewBag.Departments = GetDepartments();
            ViewBag.Designations = GetDesignations();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(EMP employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = GetDepartments();
                ViewBag.Designations = GetDesignations();
                return View(employee);
            }

            _context.Update(employee);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Details updated!";
            return RedirectToAction("Index" , "Home");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.EMP.Find(id);
            if (employee != null)
            {
                _context.EMP.Remove(employee);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Employee deleted!";
            }
            return RedirectToAction("Index", "Home");
        }

        

    }
}
