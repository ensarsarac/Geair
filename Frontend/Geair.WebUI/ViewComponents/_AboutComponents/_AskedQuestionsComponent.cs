using Geair.DTOLayer.AskedQuestionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._AboutComponents
{
    public class _AskedQuestionsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AskedQuestionsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/AskedQuestions");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAskedQuestionDto>>(readData);
            return View(values);
        }
    }
}
