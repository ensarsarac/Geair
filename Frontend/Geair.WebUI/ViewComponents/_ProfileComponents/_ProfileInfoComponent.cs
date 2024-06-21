using Geair.WebUI.Models;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._ProfileComponents
{
    public class _ProfileInfoComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _ProfileInfoComponent(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserById?id="+id);
            var read = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetUserProfileDto>(read);
            return View(value);
        }
    }
}
