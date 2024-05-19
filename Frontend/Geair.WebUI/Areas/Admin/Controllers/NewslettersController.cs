using FluentValidation.Results;
using Geair.DTOLayer.NewsletterDtos;
using Geair.WebUI.Areas.Admin.Dtos.NewsletterDtos;
using Geair.WebUI.Areas.Admin.Validation.NewsletterValidations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class NewslettersController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NewslettersController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

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
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("https://localhost:7151/api/Newsletters?id=" + id);
        return RedirectToAction("Index");
    }
    //Create
    public IActionResult CreateNewsletter()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewsletter(CreateNewsletterDto model)
    {
        CreateNewsletterDtoValidator validationRules = new CreateNewsletterDtoValidator();
        ValidationResult result = validationRules.Validate(model);
        if (result.IsValid)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7151/api/Newsletters", content);
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
    public async Task<IActionResult> UpdateNewsletter(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("https://localhost:7151/api/Newsletters/" + id);
        if (res.IsSuccessStatusCode)
        {
            var readData = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateNewsletterDto>(readData);
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
    public async Task<IActionResult> UpdateNewsletter(UpdateNewsletterDto model)
    {
        UpdateNewsletterDtoValidator validationRules = new UpdateNewsletterDtoValidator();
        ValidationResult result = validationRules.Validate(model);
        if (result.IsValid)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7151/api/Newsletters", content);
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
