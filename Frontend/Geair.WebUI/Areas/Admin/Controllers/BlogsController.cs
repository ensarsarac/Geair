using Geair.WebUI.Areas.Admin.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetBlogList()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Blogs");
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(read);
            var result = JsonConvert.SerializeObject(values);
            return Json(result);
        }



    }
}
