﻿namespace RealEstate_Dapper_API.DTOs.ProductDTOs
{
    public class ResultLast5ProductWithCategoryDTO
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}