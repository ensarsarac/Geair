using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.RoleDtos;
using Geair.WebUI.Areas.Admin.Validation.RoleValidations;
using Geair.WebUI.Models;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class RolesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _settings;
        private readonly ILoginService _loginService;

        public RolesController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _settings = settings.Value;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("Roles");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoleDto>>(read);
                return View(values);
            }
            else
            {
                ViewBag.error = "Listelenecek rol bulunamadı.";
                return View();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            CreateRoleDtoValidator validationRules = new CreateRoleDtoValidator();
            ValidationResult result = validationRules.Validate(createRoleDto);
            if(result.IsValid)
            {
                var token = _loginService.GetUserToken;
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_settings.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(createRoleDto),Encoding.UTF8,"application/json");
                 await client.PostAsync("Roles",content);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View(createRoleDto);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            await client.DeleteAsync("Roles?id=" + id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var token = _loginService.GetUserToken;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("Roles/"+id);
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateRoleDto>(read);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            UpdateRoleDtoValidator validationRules = new UpdateRoleDtoValidator();
            ValidationResult result = validationRules.Validate(updateRoleDto);
            if (result.IsValid)
            {
                var token = _loginService.GetUserToken;
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_settings.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var content = new StringContent(JsonConvert.SerializeObject(updateRoleDto), Encoding.UTF8, "application/json");
                await client.PutAsync("Roles", content);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(updateRoleDto);
            
        }
    }
}
