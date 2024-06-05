using Geair.DTOLayer.FlightDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._TicketComponents
{
    public class _FormTitleComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FormTitleComponent(IHttpClientFactory httpClientFactory)
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
            return View();
        }
    }
}
