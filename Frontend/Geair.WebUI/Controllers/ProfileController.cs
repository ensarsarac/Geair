using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Models;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Geair.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(ILoginService loginService, IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(GetUserProfileDto getUserProfileDto)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var multipart = new MultipartFormDataContent();
            multipart.Add(new StringContent(getUserProfileDto.name), "Name");
            multipart.Add(new StringContent(getUserProfileDto.surname), "Surname");
            multipart.Add(new StringContent(getUserProfileDto.email), "Email");
            multipart.Add(new StringContent(getUserProfileDto.phone), "Phone");
            multipart.Add(new StringContent(getUserProfileDto.userId.ToString()), "UserId");
            if (getUserProfileDto.imageUrl != null)
            {
                multipart.Add(new StringContent(getUserProfileDto.imageUrl), "ImageUrl");
            }

            if (getUserProfileDto.imageFile != null)
            {
                var imageContent = new StreamContent(getUserProfileDto.imageFile.OpenReadStream());
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(getUserProfileDto.imageFile.ContentType);
                multipart.Add(imageContent, "ImageFile", getUserProfileDto.imageFile.FileName);
            }
            await client.PutAsync("https://localhost:7151/api/Users/UserEditProfile", multipart);
            return RedirectToAction("Index", "Profile");
        }
    }
}
