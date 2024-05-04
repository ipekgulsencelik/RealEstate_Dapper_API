using RealEstate_Dapper_API.DTOs.ProductImageDTOs;

namespace RealEstate_Dapper_API.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        public Task<GetProductImageByProductIdDTO> GetProductImageByProductID(int id)
        {
            throw new NotImplementedException();
        }
    }
}