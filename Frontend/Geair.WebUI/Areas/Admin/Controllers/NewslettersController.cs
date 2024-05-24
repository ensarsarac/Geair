using FluentValidation.Results;
using Geair.DTOLayer.NewsletterDtos;
using Geair.WebUI.Areas.Admin.Dtos.NewsletterDtos;
using Geair.WebUI.Areas.Admin.Validation.NewsletterValidations;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Policy = "RequiredModeratorRole")]
public class NewslettersController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public NewslettersController(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }
    //List
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("https://localhost:7151/api/Newsletters");
        if (res.IsSuccessStatusCode)
        {
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Dtos.NewsletterDtos.ResultNewsletterDto>>(read);
            return View(values);
        }
        return View();
    }
    //Delete
    public async Task<IActionResult> DeleteNewsletter(int id)
    {
        var token = _loginService.GetUserToken;
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        await client.DeleteAsync("https://localhost:7151/api/Newsletters?id=" + id);
        return RedirectToAction("Index");
    }
}
