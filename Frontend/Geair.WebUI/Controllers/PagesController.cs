using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
