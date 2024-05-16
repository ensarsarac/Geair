using Microsoft.AspNetCore.Mvc;

namespace Geair.WebUI.Controllers;
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
    public IActionResult SignUp()
    {
        return View();  
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
