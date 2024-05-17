using FluentValidation.Results;
using Geair.DTOLayer.UserDtos;
using Geair.WebUI.Validations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Geair.WebUI.Controllers;
public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(RegisterUserDto model)
    {
        RegisterUserDtoValidator validationRules = new RegisterUserDtoValidator();
        ValidationResult result = validationRules.Validate(model);
        if(result.IsValid)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7151/api/Register", content);
            return RedirectToAction("SignIn");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(model);
        
    }
    public IActionResult ResetPassword()
    {
        return View();
    }
    public IActionResult ForgetPassword()
    {
        return View();
    }
}
