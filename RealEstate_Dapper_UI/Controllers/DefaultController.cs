using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7067/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
				return View(values);
			}
			return View();
		}

        [HttpGet]
        public async Task<PartialViewResult> _SearchPartial() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7067/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return PartialView(values);
            }
            return PartialView();
        }

        [HttpPost]
        public IActionResult _SearchPartial(string searchKeyValue, string city, int propertyCategoryID)
        {
			TempData["searchKeyValue"] = searchKeyValue;
			TempData["city"] = city;
			TempData["propertyCategoryID"] = propertyCategoryID;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}