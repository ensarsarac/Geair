using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.BannersDtos;
using Geair.WebUI.Areas.Admin.Validation.BannerValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class BannersController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public BannersController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7151/api/Banners");
			if (res.IsSuccessStatusCode)
			{
				var read = await res.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(read);
				return View(values);
			}
			return View();
		}
		//Delete
		public async Task<IActionResult> DeleteBanner(int id)
		{
			var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Banners?id="+id);
            return RedirectToAction("Index");
        }
		//Create
		public IActionResult CreateBanner()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto model)
        {
            var token = _loginService.GetUserToken;
            CreateBannerDtoValidator validationRules = new CreateBannerDtoValidator();
			ValidationResult result = validationRules.Validate(model);
			if(result.IsValid)
			{
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Banners", content);
                return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
                return View(model);
            }

        }
		//Update
		public async Task<IActionResult> UpdateBanner(int id)
		{
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Banners/" + id);
			if(res.IsSuccessStatusCode)
			{
				var readData = await res.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBannerDto>(readData);
				ViewBag.message = null;
                return View(value);
			}
			else
			{
				ViewBag.message = "Bu Id'ye ait veri bulunamadı.";
				return View();
            }
			
		}
		[HttpPost]
		public async Task<IActionResult> UpdateBanner(UpdateBannerDto model)
		{
            var token = _loginService.GetUserToken;
            UpdateBannerDtoValidator validationRules=new UpdateBannerDtoValidator();
			ValidationResult result = validationRules.Validate(model);
			if (result.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");
				var res =await client.PutAsync("https://localhost:7151/api/Banners", content);
				if (res.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(model);
			}
			return View();
		}




    }
}
