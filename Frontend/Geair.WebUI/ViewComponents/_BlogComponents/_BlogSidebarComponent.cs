using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._BlogComponents;

public class _BlogSidebarComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
