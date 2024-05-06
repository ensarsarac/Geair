using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _FeatureComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
