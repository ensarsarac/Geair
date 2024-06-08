using Geair.WebUI.Areas.Admin.Dtos.FlightDtos;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.ViewComponents._DashboardComponents;

public class _DashboardFlightComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public _DashboardFlightComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
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
}
