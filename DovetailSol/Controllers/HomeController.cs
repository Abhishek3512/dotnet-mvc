using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DovetailSol.Data;
using DovetailSol.Models;
using Microsoft.AspNetCore.Mvc;

namespace DovetailSol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = _context.EMP.ToList();
            return View(employees);
        }
    }
}
