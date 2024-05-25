using Geair.DTOLayer.ReservationTravelDtos;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Controllers
{
    [AllowAnonymous]
    public class ReservationTravelController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationTravelController(ILoginService loginService, IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int id)
        {
            TempData["travelid"] = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationTravelDto createReservationTravelDto)
        {
            var travelId = (int)TempData["travelid"];
            createReservationTravelDto.TravelId = travelId;
            if(User.Claims.Count()>0)
            {
                var userId = _loginService.GetUserId;
                createReservationTravelDto.UserId = Convert.ToInt32(userId);
            }
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createReservationTravelDto),Encoding.UTF8,"application/json");
            await client.PostAsync("https://localhost:7151/api/ReservationTravel", content);
            return RedirectToAction("Index","ReservationTravel", new { id = travelId });
        }
    }
}
