using Geair.DTOLayer.AirportDtos;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _BookingAreaComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _BookingAreaComponent(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var airportClient = _httpClientFactory.CreateClient();
            var airportResponse = await airportClient.GetAsync("https://localhost:7151/api/Airports");
            if (airportResponse.IsSuccessStatusCode)
            {
                var airportContent = await airportResponse.Content.ReadAsStringAsync();
                var airports = JsonConvert.DeserializeObject<List<ResultAirportDto>>(airportContent);
                ViewBag.Airports = airports;
            }
            return View();
        }
    }
}
