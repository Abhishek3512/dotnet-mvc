using DovetailSol.Models;
using Microsoft.AspNetCore.Mvc;

namespace DovetailSol.Controllers
{
        public class AccountController : Controller
        {
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(LoginModel model)
            {

                if (model.Username == "admin" && model.Password == "123")
                {
                    HttpContext.Session.SetString("IsAuthenticated", "true");
                    return RedirectToAction("Index", "HOME");
                }

                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

            public IActionResult Logout()
            {
                HttpContext.Session.Remove("IsAuthenticated");
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
        }
    }

