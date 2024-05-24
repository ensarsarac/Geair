using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.DestinationsDtos;
using Geair.WebUI.Areas.Admin.Validation.DestinationValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class DestinationsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;

        public DestinationsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
		{
			var token = _loginService.GetUserToken;
			var client = _httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			var res = await client.GetAsync("https://localhost:7151/api/Destinations");
			if (res.IsSuccessStatusCode)
			{
				var read = await res.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(read);
				return View(values);
			}
			return View();
		}
		//Delete
		public async Task<IActionResult> DeleteDestination(int id)
		{
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Destinations?id="+id);
            return RedirectToAction("Index");
        }
		//Create
		public IActionResult CreateDestination()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto model)
        {
            var token = _loginService.GetUserToken;
            CreateDestinationDtoValidator validationRules = new CreateDestinationDtoValidator();
			ValidationResult result = validationRules.Validate(model);
			if(result.IsValid)
			{
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Destinations", content);
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
		public async Task<IActionResult> UpdateDestination(int id)
		{
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Destinations/" + id);
			if(res.IsSuccessStatusCode)
			{
				var readData = await res.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateDestinationDto>(readData);
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
		public async Task<IActionResult> UpdateDestination(UpdateDestinationDto model)
		{
            var token = _loginService.GetUserToken;
            UpdateDestinationDtoValidator validationRules=new UpdateDestinationDtoValidator();
			ValidationResult result = validationRules.Validate(model);
			if (result.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");
				var res =await client.PutAsync("https://localhost:7151/api/Destinations", content);
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
