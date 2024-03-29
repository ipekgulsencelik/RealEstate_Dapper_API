using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.ProductDTOs;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;
        
        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }
        
        public async Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync(int id)
        {
            string query = "Select Top(5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}