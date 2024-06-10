using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class DashboardController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public DashboardController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IActionResult> Index()
		{
            var id = _loginService.GetUserId;
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserById?id=" + id);
            var readData = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetUserDto>(readData);
            return View(value);
        }
	}
}
