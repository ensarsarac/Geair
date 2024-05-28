using FluentValidation.Results;
using Geair.Domain.Entities;
using Geair.WebUI.Areas.Admin.Dtos.ReservationTravelDtos;
using Geair.WebUI.Areas.Admin.Dtos.TravelDtos;
using Geair.WebUI.Areas.Admin.Validation.ReservationTravelValidations;
using Geair.WebUI.Areas.Admin.Validation.TravelValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit.Text;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class TravelsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public TravelsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        //List
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Travels");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTravelDto>>(read);
                return View(values);
            }
            return View();
        }
        //Delete
        public async Task<IActionResult> DeleteTravel(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/Travels?id=" + id);
            return RedirectToAction("Index");
        }
        //Create
        public IActionResult CreateTravel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravel(CreateTravelDto model)
        {
            model.Status = true;
            model.IsFull = false;
            var token = _loginService.GetUserToken;
            CreateTravelDtoValidator validationRules = new CreateTravelDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/Travels", content);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }

        }
        //Update
        public async Task<IActionResult> UpdateTravel(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Travels/" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTravelDto>(readData);
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
        public async Task<IActionResult> UpdateTravel(UpdateTravelDto model)
        {
            var token = _loginService.GetUserToken;
            UpdateTravelDtoValidator validationRules = new UpdateTravelDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PutAsync("https://localhost:7151/api/Travels", content);
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
                return View(model);
            }
            return View();
        }

        //Travel'a ait kayıtlar
        public async Task<IActionResult> TravelResult(int id)
        {
            TempData["travelid"] = id;
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Travels/GetTravelAndReservations?id=" + id);

            var res2 = await client.GetAsync("https://localhost:7151/api/Travels/" + id);
            var readData = await res2.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<ResultTravelDto>(readData);
            ViewBag.travelTitle = value.Title;

            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultTravelReservationsDto>(read);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteReservationTravel(int id)
        {
            var travelId = (int)TempData["travelid"];
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/ReservationTravel?id=" + id);
            return RedirectToAction("TravelResult", "Travels", new { area = "Admin",id=travelId });
        }
        public async Task<IActionResult> UpdateReservationTravel(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var res2 = await client.GetAsync("https://localhost:7151/api/Travels");
            var read2 = await res2.Content.ReadAsStringAsync();
            var travels = JsonConvert.DeserializeObject<List<GetTravelTitleAndIdDto>>(read2);
            ViewBag.travelList = new SelectList(travels.ToList(), "TravelId", "Title");

            var res = await client.GetAsync("https://localhost:7151/api/ReservationTravel/GetReservationTravelById?id=" + id);
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateReservationTravelDto>(read);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservationTravel(UpdateReservationTravelDto updateReservationTravelDto)
        {
            UpdateReservationTravelDtoValidator validationRules = new UpdateReservationTravelDtoValidator();
            ValidationResult result = validationRules.Validate(updateReservationTravelDto);
            if (result.IsValid)
            {
                var token = _loginService.GetUserToken;
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(updateReservationTravelDto), Encoding.UTF8, "application/json");
                await client.PutAsync("https://localhost:7151/api/ReservationTravel", content);
                return RedirectToAction("TravelResult", "Travels", new { area = "Admin", id = updateReservationTravelDto.TravelId });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            var client3 = _httpClientFactory.CreateClient();
            var res3 = await client3.GetAsync("https://localhost:7151/api/Travels");
            var read3 = await res3.Content.ReadAsStringAsync();
            var travels = JsonConvert.DeserializeObject<List<GetTravelTitleAndIdDto>>(read3);
            ViewBag.travelList = new SelectList(travels.ToList(), "TravelId", "Title");
            return View(updateReservationTravelDto);
        }
        public async Task<IActionResult> ChangeStatusTrue(int id)
        {
            var travelId = (int)TempData["travelid"];
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.GetAsync("https://localhost:7151/api/ReservationTravel/ReservationTravelStatusTrue?id=" + id);

            var res = await client.GetAsync("https://localhost:7151/api/ReservationTravel/GetReservationTravelById?id=" + id);
            var read= await res.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<GetReservationTravelDto>(read);
            string content = "Sn."+value.Name+" "+value.Surname+"."+value.TravelTitle + " rezervasyonunuz onaylanmıştır.";
            SendMail(value.Email, content);

            return RedirectToAction("TravelResult", "Travels", new { area = "Admin", id = travelId });
        }
        
        public void SendMail(string receiveEmail,string messageBody)
        {
            var email = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
            email.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", receiveEmail);
            email.To.Add(mailboxAddressTo);

            email.Subject = "Rezervasyonunuz Onaylandı";
            email.Body = new TextPart(TextFormat.Html) { Text = messageBody };

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("ensar.src94@gmail.com", "psxb adcd kdus ymgc");
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
