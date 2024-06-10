using Geair.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Geair.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
