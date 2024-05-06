using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Areas.Admin.ViewComponents._AdminLayoutComponents
{
	public class _AdminLayoutSideBarComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
