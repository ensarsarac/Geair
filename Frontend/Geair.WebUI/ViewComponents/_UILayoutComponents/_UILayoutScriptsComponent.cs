using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._UILayoutComponents
{
    public class _UILayoutScriptsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
