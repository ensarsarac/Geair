
using Geair.DTOLayer.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._BlogComponents;

public class _BlogCategoryComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogCategoryComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("https://localhost:7151/api/Categories");
        var readData = await res.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(readData);
        return View(values);
    }
    
}
