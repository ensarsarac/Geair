using Geair.WebUI.Areas.Admin.Dtos.BlogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class BlogsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public BlogsController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogAjax(CreateBlogDto createBlogDto)
        {
            createBlogDto.Date = DateTime.Now;
            createBlogDto.UserId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            createBlogDto.CategoryId = 1;
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createBlogDto),Encoding.UTF8,"application/json");
            await client.PostAsync("https://localhost:7151/api/Blogs",content);
            var result = JsonConvert.SerializeObject(createBlogDto);
            return Json(result);
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
