using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._UILayoutComponents
{
    public class _UILayoutNavbarComponent:ViewComponent
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public _UILayoutNavbarComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.user = _contextAccessor.HttpContext.User.FindFirst("fullname").Value;
            return View();
        }
    }
}
