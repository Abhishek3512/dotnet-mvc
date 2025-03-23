using DovetailSol.Data;
using DovetailSol.Models;
using Microsoft.AspNetCore.Mvc;

namespace DovetailSol.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Designations = GetDesignations();
            //ViewBag.SelectedDesignation = null;
            return View(new List<EMP>());
        }

        [HttpPost]
        public IActionResult FilterDesignation(string designation)
        {
            ViewBag.Designations = GetDesignations();
            ViewBag.SelectedDesignation = designation;

            var employees = _context.EMP
                .Where(e => e.Designation == designation)
                .ToList();
            return View("Index", employees);
        }

        private List<string> GetDesignations()
        {
            return _context.EMP.Select(e => e.Designation).Distinct().ToList();
        }
    }
}
