using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.BlogDtos;
using Geair.WebUI.Areas.Admin.Validation.BlogsValidations;
using Geair.WebUI.Services;
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
        private readonly ILoginService _loginService;

        public BlogsController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _contextAccessor = contextAccessor;
            _loginService = loginService;
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
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var token = _loginService.GetUserToken;
            createBlogDto.Date = DateTime.Now;
            createBlogDto.UserId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            createBlogDto.CategoryId = 1;
            CreateBlogDtoValidator validationRules = new CreateBlogDtoValidator();
            ValidationResult result = validationRules.Validate(createBlogDto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(new { errors });
            }
           
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var content = new StringContent(JsonConvert.SerializeObject(createBlogDto), Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7151/api/Blogs", content);
            return RedirectToAction("Index");
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
