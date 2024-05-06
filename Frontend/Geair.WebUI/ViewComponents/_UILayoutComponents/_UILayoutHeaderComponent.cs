using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._UILayoutComponents
{
    public class _UILayoutHeaderComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
