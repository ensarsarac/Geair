using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILoginService _loginService;

        public DefaultController(IHttpContextAccessor contextAccessor, ILoginService loginService)
        {
            _contextAccessor = contextAccessor;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            //var user = _contextAccessor.HttpContext.User.FindFirst("fullname")?.Value;
            //if(user != null)
            //{
            //    ViewBag.user = user;
            //}
            //else{
            //    ViewBag.user = "";
            //}
            return View();
        }
    }
}
