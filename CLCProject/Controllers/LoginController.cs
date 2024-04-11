using Microsoft.AspNetCore.Mvc;

namespace CLCProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
