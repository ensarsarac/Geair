using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.SocialMediaDtos;
using Geair.WebUI.Areas.Admin.Validation.SocialMediaValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class SocialMediasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public SocialMediasController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        //List
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/SocialMedias");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(read);
                return View(values);
            }
            return View();
        }
        //Delete
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("https://localhost:7151/api/SocialMedias?id=" + id);
            return RedirectToAction("Index");
        }
        //Create
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto model)
        {
            var token = _loginService.GetUserToken;
            CreateSocialMediaDtoValidator validationRules = new CreateSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7151/api/SocialMedias", content);
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
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/SocialMedias/" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(readData);
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
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto model)
        {
            var token = _loginService.GetUserToken;
            UpdateSocialMediaDtoValidator validationRules = new UpdateSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PutAsync("https://localhost:7151/api/SocialMedias", content);
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
    }
}
