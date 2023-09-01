using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var serviceClient = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7067/api/WhoWeAreDetail");
            var serviceResponseMessage = await client.GetAsync("https://localhost:7067/api/Service");

            if (responseMessage.IsSuccessStatusCode && serviceResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonDataService = await serviceResponseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDTO>>(jsonData);
                var services = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonDataService);

                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.description = value.Select(x => x.Description).FirstOrDefault();
                ViewBag.subDescription = value.Select(x => x.SubDescription).FirstOrDefault();

                return View(services);
            }
            return View();
        }
    }
}