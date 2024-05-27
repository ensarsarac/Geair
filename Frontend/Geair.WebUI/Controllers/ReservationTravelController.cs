using FluentValidation.Results;
using Geair.DTOLayer.ReservationTravelDtos;
using Geair.DTOLayer.TravelDtos;
using Geair.WebUI.Services;
using Geair.WebUI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
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
			TempData["travelname"] = ViewBag.values.Title;
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
				string travelName = (string)TempData["travelname"];
				string mailBody = "Sn."+createReservationTravelDto.Name+" "+createReservationTravelDto.Surname+". "+travelName+", seyahatimize kaydınız alınmıştır. En kısa sürede sizi arayıp onay alınacaktır.Detaylar Kişi Sayısı:"+createReservationTravelDto.PersonCount+", Email:"+createReservationTravelDto.Email+", Telefon Numaranız:"+createReservationTravelDto.Phone+", Toplam Fiyat:"+createReservationTravelDto.TotalPrice;
				SendMail(createReservationTravelDto.Email,mailBody);
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

		public void SendMail(string mail,string mailBody)
		{
			var email = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
			email.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);
			email.To.Add(mailboxAddressTo);

			email.Subject = "Rezervasyonunuz Alındı";
			email.Body = new TextPart(TextFormat.Html) { Text = mailBody };

			var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			smtp.Authenticate("ensar.src94@gmail.com", "psxb adcd kdus ymgc");
			smtp.Send(email);
			smtp.Disconnect(true);
		}



	}
}
