using RealEstate_Dapper_API.DTOs.ProductDTOs;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync(int id);
    }
}