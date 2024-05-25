using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.ViewComponents._BlogComponents;

public class _BlogNewsletterComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
