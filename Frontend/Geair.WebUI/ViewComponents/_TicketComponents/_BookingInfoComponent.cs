using Geair.DTOLayer.FlightDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._TicketComponents
{
    public class _BookingInfoComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BookingInfoComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var flightInfo = await client.GetAsync("https://localhost:7151/api/Flights/GetFlightById?id=" + id);
            var read = await flightInfo.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFlightDto>(read);
            ViewBag.flight = value.DepartureAirportCity.Split(',')[0] + " - " + value.ArrivalAirportCity.Split(",")[0];
            ViewBag.flightDeparatureDate = value.DepartureTime.ToShortDateString();
            ViewBag.flightDeparatureTime = value.DepartureTime.ToShortTimeString();
            ViewBag.flightDeparatureCity = value.DepartureAirportCity;
            ViewBag.flightArrivalDate = value.ArrivalTime.ToShortDateString();
            ViewBag.flightArrivalTime = value.ArrivalTime.ToShortTimeString();
            ViewBag.flightArrivalCity = value.ArrivalAirportCity;
            ViewBag.dateofreturn = value.DateOfReturn;
            ViewBag.economy = value.EconomyPrice;
            ViewBag.business = value.BusinessPrice;
            ViewBag.flightType = value.FlightType;
            return View(value);
        }
    }
}
