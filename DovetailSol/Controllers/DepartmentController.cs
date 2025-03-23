using DovetailSol.Data;
using DovetailSol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DovetailSol.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Departments = GetDepartments();
            //ViewBag.SelectedDepartment = null; 
            return View(new List<EMP>());
        }

        [HttpPost]
        public IActionResult FilterDepartment(string department)
        {
            ViewBag.Departments = GetDepartments();
            //ViewBag.SelectedDepartment = department;

            var employees = _context.EMP
                .Where(e => e.Department == department)
                .ToList();
            return View("Index", employees);
        }
        private List<string> GetDepartments()
        {
            return _context.EMP.Select(e => e.Department).Distinct().ToList();
        }
    }
}
