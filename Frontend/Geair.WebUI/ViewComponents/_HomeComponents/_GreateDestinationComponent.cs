using Geair.DTOLayer.TravelDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _GreateDestinationComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GreateDestinationComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Travels/GetLast4TravelList");
            var readData = await res.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultLast4TravelDto>>(readData);
            return View(jsonData);
        }
    }
}
