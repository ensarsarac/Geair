using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.AircraftDtos;
using Geair.WebUI.Areas.Admin.Validation.AircraftValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class AircraftsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public AircraftsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Aircrafts");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAircraftDto>>(read);
                return View(values);
            }
            return View();
        }

        //Delete
        public async Task<IActionResult> DeleteAircraft(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Aircrafts?id=" + id);
            return RedirectToAction("Index");
        }

        //Create
        [HttpGet]
        public IActionResult CreateAircraft()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAircraft(CreateAircraftDto createAircraftDto)
        {
            var token = _loginService.GetUserToken;
            CreateAircraftDtoValidator validationRules = new CreateAircraftDtoValidator();
            ValidationResult result = validationRules.Validate(createAircraftDto);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(createAircraftDto), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Aircrafts", content);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createAircraftDto);
            }
        }

        //Update
        [HttpGet]
        public async Task<IActionResult> UpdateAircraft(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Aircrafts/" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAircraftDto>(readData);
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
        public async Task<IActionResult> UpdateAircraft(UpdateAircraftDto updateAircraftDto)
        {
            var token = _loginService.GetUserToken;
            UpdateAircraftDtoValidator validationRules = new UpdateAircraftDtoValidator();
            ValidationResult result = validationRules.Validate(updateAircraftDto);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(updateAircraftDto), Encoding.UTF8, "application/json");
                var res = await client.PutAsync("https://localhost:7151/api/Aircrafts", content);
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
                return View(updateAircraftDto);
            }
            return View();
        }

        // Koltuklar Listesi
        public async Task<IActionResult> AircraftSeats(int id)
        {
            TempData["aircraftid"] = id;
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Aircrafts/GetAircraftAndSeats?id=" + id);

            var res2 = await client.GetAsync("https://localhost:7151/api/Aircrafts/" + id);
            var readData = await res2.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<ResultAircraftDto>(readData);

            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAircraftSeatsDto>(read);
                return View(values);
            }
            return View();
        }

        // Koltuklar Create
        [HttpGet]
        public IActionResult CreateSeat(int id)
        {
            var model = new CreateAircraftSeatsDto()
            {
                AircraftId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat(CreateAircraftSeatsDto createAircraftSeatsDto)
        {
            var token = _loginService.GetUserToken;
            CreateAircraftSeatsDtoValidator validationRules = new CreateAircraftSeatsDtoValidator();
            ValidationResult result = validationRules.Validate(createAircraftSeatsDto);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(createAircraftSeatsDto), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Seats", content);
                return RedirectToAction("AircraftSeats", new { id = createAircraftSeatsDto.AircraftId});
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createAircraftSeatsDto);
            }
        }

        // Koltuklar Delete
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var aircraftId = (int)TempData["aircraftid"];
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Seats?id=" + id);
            return RedirectToAction("AircraftSeats", new { id = aircraftId});
        }

    }
}
