﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7140/api/Discount/GetListByStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
