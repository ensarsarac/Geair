using FluentValidation.Results;
using Geair.Domain.Entities;
using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Areas.Admin.Validation.UserValidations;
using Geair.WebUI.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public ProfileController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserById?id="+id);
            var readData = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetUserDto>(readData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Index(GetUserDto getUserDto) 
        {
            GetUserDtoValidator validationRules = new GetUserDtoValidator();
            ValidationResult result = validationRules.Validate(getUserDto);
            if (result.IsValid)
            {
                var token = _loginService.GetUserToken;
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var multipart = new MultipartFormDataContent();
                multipart.Add(new StringContent(getUserDto.Name),"Name");  
                multipart.Add(new StringContent(getUserDto.Surname),"Surname");  
                multipart.Add(new StringContent(getUserDto.Email),"Email");  
                multipart.Add(new StringContent(getUserDto.Phone),"Phone");  
                multipart.Add(new StringContent(getUserDto.UserId.ToString()),"UserId");  
                if(getUserDto.ImageUrl != null)
                {
                    multipart.Add(new StringContent(getUserDto.ImageUrl), "ImageUrl");
                }

                if (getUserDto.ImageFile != null)
                {
                    var imageContent = new StreamContent(getUserDto.ImageFile.OpenReadStream());
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue(getUserDto.ImageFile.ContentType);
                    multipart.Add(imageContent, "ImageFile", getUserDto.ImageFile.FileName);
                } 
                var res = await client.PutAsync("https://localhost:7151/api/Users/UserEditProfile", multipart);
                if(res.IsSuccessStatusCode)
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
            }
            return View(getUserDto);
        }

    }
}
