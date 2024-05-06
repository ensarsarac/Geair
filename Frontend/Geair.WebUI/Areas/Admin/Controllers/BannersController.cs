using Geair.DTOLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BannersController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BannersController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7151/api/Banners");
			if (res.IsSuccessStatusCode)
			{
				var read = await res.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(read);
				return View(values);
			}
			else
			{
				ViewBag.error = "Veriler yüklenirken bir hata oluştu..";
				return View();
			}
			
		}
	}
}
