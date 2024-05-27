using Geair.DTOLayer.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _PostComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PostComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Blogs/GetBlogListClientHome");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBlogHomeDto>>(readData);
            return View(values);
        }
    }
}
