using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.BlogDtos;
using Geair.WebUI.Areas.Admin.Dtos.CategoryDtos;
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
        
        public async Task<IActionResult> CreateBlog()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Categories");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                ViewBag.categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(read);
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var token = _loginService.GetUserToken;
            createBlogDto.Date = DateTime.Now;
            createBlogDto.UserId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
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

        public async Task<IActionResult> UpdateBlog(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Blogs/" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogDto>(readData);
                ViewBag.message = null;

                var resCat = await client.GetAsync("https://localhost:7151/api/Categories");
                if (resCat.IsSuccessStatusCode)
                {
                    var read = await resCat.Content.ReadAsStringAsync();
                    ViewBag.categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(read);
                    return View(value);
                }
                else
                {
                    ViewBag.message = "Bu Id'ye ait Kategori verisi bulunamadı.";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.message = "Bu Id'ye ait veri bulunamadı.";
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var token = _loginService.GetUserToken;
            updateBlogDto.Date = DateTime.Now;
            updateBlogDto.UserId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            UpdateBlogDtoValidator validationRules = new UpdateBlogDtoValidator();
            ValidationResult result = validationRules.Validate(updateBlogDto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(new { errors });
            }
           
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var content = new StringContent(JsonConvert.SerializeObject(updateBlogDto), Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7151/api/Blogs", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Blogs?id=" + id);
            return RedirectToAction("Index");
        }

    }
}
