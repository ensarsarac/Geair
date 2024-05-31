using Geair.DTOLayer.FlightDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FlightsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightList");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFlightDto>>(readData);
            return View(values);
        }
    }
}
