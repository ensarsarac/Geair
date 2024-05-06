using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._AboutComponents
{
    public class _AboutBreadCrumbComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
