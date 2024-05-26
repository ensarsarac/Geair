using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._BlogComponents;

public class _BlogDetailComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
