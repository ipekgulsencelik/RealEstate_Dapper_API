using RealEstate_Dapper_API.DTOs.ProductImageDTOs;

namespace RealEstate_Dapper_API.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<GetProductImageByProductIdDTO> GetProductImageByProductID(int id);
    }
}