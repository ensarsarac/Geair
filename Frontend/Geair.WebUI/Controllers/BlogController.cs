using Geair.DTOLayer.BlogDtos;
using Geair.WebUI.Areas.Admin.Dtos.FlightOptionsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.Controllers;
[AllowAnonymous]
public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public IActionResult Index(int? id)
    {
        if (id == null)
        {
            ViewBag.categoryId = 0;
        } else
        {
            ViewBag.categoryId = id;
        }
        return View();
    }

    public async Task<IActionResult> Detail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("https://localhost:7151/api/Blogs/" + id);
        var readData = await res.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ResultBlogDto>(readData);
        return View(values);
    }
}
