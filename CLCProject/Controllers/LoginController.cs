using CLCProject.Models;
using CLCProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CLCProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SecurityService _securityService;

        public LoginController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult Index()
        {
            return View(); // Assuming there's a corresponding view called Index.cshtml
        }

        [HttpPost]
        public IActionResult ProcessLogin(UserModel user)
        {
            if (_securityService.IsValid(user))
            {
                return RedirectToAction("LoginSuccess");
            }
            else
            {
                return RedirectToAction("LoginFailure");
            }
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }

        public IActionResult LoginFailure()
        {
            return View();
        }
    }
}
