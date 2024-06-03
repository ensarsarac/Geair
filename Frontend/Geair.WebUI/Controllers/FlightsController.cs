using Geair.DTOLayer.FlightDtos;
using Geair.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using X.PagedList;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class FlightsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FlightsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                if (res.IsSuccessStatusCode) return View(values);
                else
                {
                    ViewBag.Errors = "Girdiğiniz kriterlerde herhangi bir uçuş bulunamadı.";
                    return View();
                }
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
    }
}
