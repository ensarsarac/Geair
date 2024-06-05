using FluentValidation.Results;
using Geair.DTOLayer.FlightDtos;
using Geair.DTOLayer.TicketDtos;
using Geair.WebUI.Models;
using Geair.WebUI.Services;
using Geair.WebUI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class FlightsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public FlightsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IActionResult> Index(string? FromWhere,string? ToWhere,DateTime? Departure,DateTime? Arrival,int page=1,int pageSize = 3)
        {
            if (!string.IsNullOrEmpty(FromWhere) && !string.IsNullOrEmpty(ToWhere) && !string.IsNullOrEmpty(Departure.ToString()) && !string.IsNullOrEmpty(Arrival.ToString()))
            {
                var model = new FlightFilterViewModel
                {
                    Arrival = (DateTime)Arrival,
                    Departure = (DateTime)Departure,
                    FromWhere = FromWhere,
                    ToWhere = ToWhere,
                };
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");   
                var res = await client.PostAsync("https://localhost:7151/api/Flights/GetFlightByFilter",content);
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFlightDto>>(read).ToPagedList(page,pageSize);
                if (values.Count()<=0)
                {
                    ViewBag.Errors = "Girdiğiniz kriterlerde herhangi bir uçuş bulunamadı.";
                    return View(values);
                }
                if (res.IsSuccessStatusCode)
                {
                    ViewBag.Errors = null;
                    return View(values);
                }
                return View();
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var res = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightListByStatusTrue");
                var readData = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFlightDto>>(readData).ToPagedList(page, pageSize);
                return View(values);
            }
            
        }

        public async Task<IActionResult> Ticket(int id)
        {
            TempData["id"] = id;
            ViewBag.id = id;
            var client = _httpClientFactory.CreateClient();
            var flightInfo = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightById?id=" + id);
            var read = await flightInfo.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFlightDto>(read);
            ViewBag.economy = value.EconomyPrice;
            ViewBag.business = value.BusinessPrice;
            ViewBag.flightType = value.FlightType;

            return View(new CreateTicketDto { FlightId = id,DateOfReturn=value.DateOfReturn});
        }
        [HttpPost]
        public async Task<IActionResult> Ticket(CreateTicketDto createTicketDto)
        {
            CreateTicketDtoValidator validationRules = new CreateTicketDtoValidator();
            ValidationResult result = validationRules.Validate(createTicketDto);
            if (result.IsValid)
            {
                if(User.Claims.Count() > 0)
                {
                    var userId = _loginService.GetUserId;
                    createTicketDto.UserId = Convert.ToInt32(userId);
                }
                createTicketDto.Status = false;
                createTicketDto.FlyNumber = Guid.NewGuid().ToString();
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(createTicketDto), Encoding.UTF8, "application/json");
                var res = await client.PostAsync("https://localhost:7151/api/Tickets", content);

                if(res.IsSuccessStatusCode)
                {
                    ViewBag.errorList = null;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            var id = (int)TempData["id"];
            ViewBag.id = id;
            var client2 = _httpClientFactory.CreateClient();
            var flightInfo = await client2.GetAsync("https://localhost:7151/api/Flights/GetFlightById?id=" + id);
            var read = await flightInfo.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFlightDto>(read);
            ViewBag.economy = value.EconomyPrice;
            ViewBag.business = value.BusinessPrice;
            ViewBag.flightType = value.FlightType;
            return View(createTicketDto);

        }
    }
}
