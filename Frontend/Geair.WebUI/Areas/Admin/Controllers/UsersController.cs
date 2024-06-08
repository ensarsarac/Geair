using Geair.WebUI.Areas.Admin.Dtos.RoleDtos;
using Geair.WebUI.Areas.Admin.Dtos.UserDtos;
using Geair.WebUI.Areas.Admin.Models;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminRole")]
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public UsersController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var token = _loginService.GetUserToken;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Users/GetUserList");
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetUserListDto>>(read);
            return View(values);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            TempData["userid"] = id;
            var client = _httpClientFactory.CreateClient();
            var token = _loginService.GetUserToken;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var res = await client.GetAsync("https://localhost:7151/api/Roles");
            var read = await res.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<List<ResultRoleDto>>(read);

            var res2 = await client.GetAsync("https://localhost:7151/api/Users/GetUserAndRole?id=" + id);
            var read2 = await res2.Content.ReadAsStringAsync();
            var userRoles = JsonConvert.DeserializeObject<GetUserAndRoleDto>(read2);

            List<AssignRoleViewModel> list = new List<AssignRoleViewModel>();
            foreach (var item in roles)
            {
                list.Add(new AssignRoleViewModel
                {
                    Id = item.RoleId,
                    RoleName = item.RoleName,
                    IsExist = userRoles.RoleName.Contains(item.RoleName),
                    Name = userRoles.Name,
                    Surname=userRoles.Surname,
                });
            }

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> assignRoleViewModels)
        {
            var userId = (int)TempData["userid"];
            var client = _httpClientFactory.CreateClient();
            for (int i = 0; i < assignRoleViewModels.Count(); i++)
            {
                if (assignRoleViewModels[i].IsExist)
                {
                    var result = new SendUserRole
                    {
                        RoleId = assignRoleViewModels[i].Id,
                        UserId = userId,
                    };
                    var content = new StringContent(JsonConvert.SerializeObject(result),Encoding.UTF8,"application/json");
                    await client.PutAsync("https://localhost:7151/api/Users/UpdateUserRole", content);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
