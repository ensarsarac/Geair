using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Geair.DTOLayer.BrandDtos;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _BrandComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BrandComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Brands");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(readData);
            return View(values);
        }
    }
}
