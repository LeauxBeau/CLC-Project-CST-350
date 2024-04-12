using Microsoft.AspNetCore.Mvc;

namespace CLCProject.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}