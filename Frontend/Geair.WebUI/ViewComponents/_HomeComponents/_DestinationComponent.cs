using Geair.DTOLayer.DestinationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _DestinationComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DestinationComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Destinations");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(readData);
            return View(values);
        }
    }
}
