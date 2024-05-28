using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.AirportDtos;
using Geair.WebUI.Areas.Admin.Validation.AirportValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class AirportsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public AirportsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Airports");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAirportDto>>(read);
                return View(values);
            }
            return View();
        }
        //Delete
        public async Task<IActionResult> DeleteAirport(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Airports?id=" + id);
            return RedirectToAction("Index");
        }
        //Create
        public IActionResult CreateAirport()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAirport(CreateAirportDto model)
        {
            var token = _loginService.GetUserToken;
            CreateAirportDtoValidator validationRules = new CreateAirportDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Airports", content);
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
        public async Task<IActionResult> UpdateAirport(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Airports/" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAirportDto>(readData);
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
        public async Task<IActionResult> UpdateAirport(UpdateAirportDto model)
        {
            var token = _loginService.GetUserToken;
            UpdateAirportDtoValidatior validationRules = new UpdateAirportDtoValidatior();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PutAsync("https://localhost:7151/api/Airports", content);
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
