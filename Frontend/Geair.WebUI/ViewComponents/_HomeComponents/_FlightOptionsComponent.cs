using Geair.DTOLayer.FlightOptionsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _FlightOptionsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FlightOptionsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/FlightOptions");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFlightOptionsDto>>(readData);
            return View(values);
        }
    }
}
