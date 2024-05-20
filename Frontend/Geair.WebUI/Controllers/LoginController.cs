using FluentValidation.Results;
using Geair.DTOLayer.UserDtos;
using Geair.WebUI.Models;
using Geair.WebUI.Validations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(LoginUserDto loginUserDto)
    {
        LoginUserDtoValidator validationRules = new LoginUserDtoValidator();
        ValidationResult result = validationRules.Validate(loginUserDto);
        if (result.IsValid)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginUserDto),Encoding.UTF8,"application/json");
            var res = await client.PostAsync("https://localhost:7151/api/Login", content);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<JwtTokenResult>(readData);
                if(jsonData != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(jsonData.Token);
                    var claims = token.Claims.ToList();
                    if(jsonData.Token != null)
                    {
                        claims.Add(new Claim("Token", jsonData.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = jsonData.ExpireDate,
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }
            else 
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış";
            }
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
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
