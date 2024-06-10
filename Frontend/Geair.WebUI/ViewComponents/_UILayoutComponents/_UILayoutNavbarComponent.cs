using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._UILayoutComponents
{
    public class _UILayoutNavbarComponent : ViewComponent
    {
        private readonly ILoginService _loginService;

        public _UILayoutNavbarComponent(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.userRole = _loginService.GetUserRole;
            return View();
        }
    }
}
