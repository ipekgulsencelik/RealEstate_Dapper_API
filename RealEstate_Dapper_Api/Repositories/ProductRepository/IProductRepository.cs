using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_API.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync();
        Task<List<ResultGetProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertsListByEmployeeAsync(int id);
    }
}