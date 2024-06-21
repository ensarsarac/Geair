using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
