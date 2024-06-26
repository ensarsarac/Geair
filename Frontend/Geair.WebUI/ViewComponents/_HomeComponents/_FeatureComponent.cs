﻿using Geair.DTOLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geair.WebUI.ViewComponents._HomeComponents
{
    public class _FeatureComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeatureComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Features");
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(readData);
            return View(values);
        }
    }
}
