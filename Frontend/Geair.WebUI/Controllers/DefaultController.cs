using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
