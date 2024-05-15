using Geair.DTOLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._AboutComponents
{
    public class _WhoWeAreComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _WhoWeAreComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Abouts");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(readData);
            return View(values.FirstOrDefault());
        }
    }
}
