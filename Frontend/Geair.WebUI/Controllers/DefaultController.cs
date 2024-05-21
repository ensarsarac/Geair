using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            var user = _contextAccessor.HttpContext.User.FindFirst("fullname")?.Value;
            if(user != null)
            {
                ViewBag.user = user;
            }
            else{
                ViewBag.user = "";
            }
            return View();
        }
    }
}
