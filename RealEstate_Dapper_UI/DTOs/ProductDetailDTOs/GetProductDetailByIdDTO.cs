namespace RealEstate_Dapper_UI.DTOs.ProductDetailDTOs
{
    public class GetProductDetailByIdDTO
    {
        public int ProductDetailID { get; set; }
        public int BedroomCount { get; set; }
        public int ProductSize { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoURL { get; set; }
        public int ProductID { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}