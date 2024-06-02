using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.AircraftDtos;
using Geair.WebUI.Areas.Admin.Dtos.AirportDtos;
using Geair.WebUI.Areas.Admin.Dtos.FlightDtos;
using Geair.WebUI.Areas.Admin.Validation.FlightValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminRole")]
    [Area("Admin")]
    public class FlightsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public FlightsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightList");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFlightDto>>(read);
                return View(values);
            }
            return View();
        }
        //Delete
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Flights?id=" + id);
            return RedirectToAction("Index");
        }
        //Create
        public async Task<IActionResult> CreateFlight()
        {
            await GetAirportAndAircraftList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDto model)
        {
            model.Status = true;
            var token = _loginService.GetUserToken;
            CreateFlightDtoValidator validationRules = new CreateFlightDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PostAsync("https://localhost:7151/api/Flights", content);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    await GetAirportAndAircraftList();
                    return View(model);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                await GetAirportAndAircraftList();
                return View(model);
            }

        }
        //Update
        public async Task<IActionResult> UpdateFlight(int id)
        {
            
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightById?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                await GetAirportAndAircraftList();
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFlightDto>(readData);
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
        public async Task<IActionResult> UpdateFlight(UpdateFlightDto model)
        {
            var token = _loginService.GetUserToken;
            UpdateFlightDtoValidator validationRules = new UpdateFlightDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PutAsync("https://localhost:7151/api/Flights", content);
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
                await GetAirportAndAircraftList();
                return View(model);
            }
            return View();
        }
        public async Task GetAirportAndAircraftList()
        {
            var client = _httpClientFactory.CreateClient();

            var airport = await client.GetAsync("https://localhost:7151/api/Airports");
            var readData = await airport.Content.ReadAsStringAsync();
            var airportJson = JsonConvert.DeserializeObject<List<ResultAirportDto>>(readData);
            ViewBag.airportValues = new SelectList(airportJson?.ToList(), "AirportId", "AirportTitle");

            var aircraft = await client.GetAsync("https://localhost:7151/api/Aircrafts");
            var aircraftReadData = await aircraft.Content.ReadAsStringAsync();
            var aircraftJson = JsonConvert.DeserializeObject<List<ResultAircraftDto>>(aircraftReadData);
            ViewBag.aircraftValues = new SelectList(aircraftJson?.ToList(), "AircraftId", "Model");
        }
    }
}
