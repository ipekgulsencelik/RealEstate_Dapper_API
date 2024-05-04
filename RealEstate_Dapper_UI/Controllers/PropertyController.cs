using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;
using RealEstate_Dapper_UI.DTOs.ProductDetailDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7067/api/PopularLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;

            var productClient = _httpClientFactory.CreateClient();
            var response = await productClient.GetAsync("https://localhost:7067/api/Products/GetProductByProductID?id=" + id);
            var jsonProductData = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ResultProductDTO>(jsonProductData);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7067/api/ProductDetails/GetProductDetailByProductID?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetProductDetailByIdDTO>(jsonData);

            ViewBag.mainTitle = product.Title.ToString();
            ViewBag.price = product.Price;
            ViewBag.city = product.City;
            ViewBag.district = product.District;
            ViewBag.address = product.Address;
            ViewBag.type = product.Type;

            ViewBag.bathCount = values.BathCount;
            ViewBag.bedCount = values.BedroomCount;
            ViewBag.size = values.ProductSize;

            DateTime currentDate = DateTime.Now;
            DateTime advertisementDate = product.AdvertisementDate;

            TimeSpan timeSpan = currentDate - advertisementDate;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;

            return View();
        }
    }
}