using Microsoft.AspNetCore.Mvc;

namespace HobbyPortal.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
