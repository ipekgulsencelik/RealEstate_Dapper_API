namespace RealEstate_Dapper_API.DTOs.ProductImageDTOs
{
    public class GetProductImageByProductIdDTO
    {
        public int ProductImageID { get; set; }
        public string ImageURL { get; set; }
        public int ProductID { get; set; }
    }
}