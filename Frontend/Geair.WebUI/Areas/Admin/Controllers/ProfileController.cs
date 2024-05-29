using Geair.Domain.Entities;
using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProfileController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserById?id=13");
            var readData = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetUserDto>(readData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Index(GetUserDto getUserDto) 
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(getUserDto),Encoding.UTF8,"application/json");
            await client.PutAsync("https://localhost:7151/api/Users",content);
            return View();
        }




    }
}
