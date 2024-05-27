using FluentValidation.Results;
using Geair.DTOLayer.ReservationTravelDtos;
using Geair.DTOLayer.TravelDtos;
using Geair.WebUI.Services;
using Geair.WebUI.Validations;
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

		public async Task<IActionResult> Index(int id)
		{
			TempData["travelid"] = id;
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7151/api/Travels/" + id);
			var readData = await res.Content.ReadAsStringAsync();
			ViewBag.values = JsonConvert.DeserializeObject<ReservationTravelSummaryDto>(readData);
			return View(new CreateReservationTravelDto { TravelId=id});
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateReservationTravelDto createReservationTravelDto)
		{
			var travelId = createReservationTravelDto.TravelId;
			createReservationTravelDto.Status = false;
			CreateReservationTravelDtoValidator validationRules = new CreateReservationTravelDtoValidator();
			ValidationResult result = validationRules.Validate(createReservationTravelDto);
			if (result.IsValid)
			{
				createReservationTravelDto.TravelId = travelId;
				if (User.Claims.Count() > 0)
				{
					var userId = _loginService.GetUserId;
					createReservationTravelDto.UserId = Convert.ToInt32(userId);
				}
				var client = _httpClientFactory.CreateClient();
				var content = new StringContent(JsonConvert.SerializeObject(createReservationTravelDto), Encoding.UTF8, "application/json");
				await client.PostAsync("https://localhost:7151/api/ReservationTravel", content);
				TempData["successMessage"] = "Kaydınız başarıyla alındı. En kısa sürede size geri dönüş yapacağız.";
				return RedirectToAction("Index", "ReservationTravel",new {id=travelId});
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				var client = _httpClientFactory.CreateClient();
				var res = await client.GetAsync("https://localhost:7151/api/Travels/" + travelId);
				var readData = await res.Content.ReadAsStringAsync();
				ViewBag.values = JsonConvert.DeserializeObject<ReservationTravelSummaryDto>(readData);
				TempData["successMessage"] = null;
				return View(createReservationTravelDto);
			}
		}





	}
}
