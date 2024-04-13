using Microsoft.AspNetCore.Mvc;

namespace CLCProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
