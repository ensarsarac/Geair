using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Areas.Admin.ViewComponents._AdminLayoutComponents
{
	public class _AdminLayoutHeadComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
