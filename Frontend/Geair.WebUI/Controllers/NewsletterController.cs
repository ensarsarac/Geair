using FluentValidation.Results;
using Geair.WebUI.Areas.Admin.Dtos.NewsletterDtos;
using Geair.WebUI.Areas.Admin.Validation.NewsletterValidations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Controllers;
[AllowAnonymous]
public class NewsletterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NewsletterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

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
            return RedirectToAction("Index","Default");
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
}
