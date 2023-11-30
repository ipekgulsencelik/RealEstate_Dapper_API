﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

            #region ProductCount
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7067/api/Statistics/ProductCount");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			ViewBag.ProductCount = jsonData1;
            #endregion

            #region EmployeeNameByMaxProductCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7067/api/Statistics/EmployeeNameByMaxProductCount");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.EmployeeNameByMaxProductCount = jsonData2;
            #endregion

            #region DifferentCityCount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7067/api/Statistics/DifferentCityCount");
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
			ViewBag.DifferentCityCount = jsonData3;
            #endregion

            #region avergeProductPriceByRent
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7067/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion

            return View();
		}
	}
}