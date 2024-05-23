using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_API.DTOs.ProductDetailDTOs;
using RealEstate_Dapper_API.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync();
        Task CreateProduct(CreateProductDTO createProductDTO);
        Task<GetProductByProductIdDTO> GetProductByProductID(int id);
        Task<GetProductDetailByIdDTO> GetProductDetailByProductID(int id);
        Task<List<ResultProductWithSearchListDTO>> GetProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
    }
}