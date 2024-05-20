using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Geair.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            //ViewBag.v = _contextAccessor.HttpContext.User.FindFirst("fullname").Value;
            return View();
        }
    }
}
