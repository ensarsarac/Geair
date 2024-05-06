using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._AboutComponents
{
    public class _WhoWeAreComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
