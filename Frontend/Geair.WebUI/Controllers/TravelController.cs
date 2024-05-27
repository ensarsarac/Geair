using Geair.DTOLayer.TravelDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class TravelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TravelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Travels/GetTravelListOrderBy");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTravelListOrderByDto>>(readData);
            return View(values);
        }
    }
}
