using CLCProject.Models;
using CLCProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CLCProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
                return View("LoginSuccess", user);
            else
                return View("LoginFailure", user);
        }
    }
}
