using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.ViewComponents._AdminLayoutComponents
{
	public class _AdminLayoutSideBarComponent:ViewComponent
	{
        private readonly ILoginService _loginService;
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLayoutSideBarComponent(ILoginService loginService, IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var id = _loginService.GetUserId;
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserImageAndName?id="+id);
            var read = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetUserImageAndName>(read);
            ViewBag.user = value;
			return View();
		}
	}
}
