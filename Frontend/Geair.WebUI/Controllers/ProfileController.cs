using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
