using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.ProductDetailDTOs;
using RealEstate_Dapper_API.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            string query = "Select * From Products";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay From Products inner join Category on Products.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address ,DealOfTheDay From Products inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay From Products inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Products Set DealOfTheDay=0 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Products Set DealOfTheDay=1 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID, Title, Price, City,District, ProductCategory, CategoryName, AdvertisementDate From Products Inner Join Category On Products.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDTO> GetProductByProductID(int id)
        {
            string query = "Select ProductID, Title, Price, City, District, Description, CategoryName, CoverImage, Type, Address, DealOfTheDay, AdvertisementDate From Products inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIdDTO>(query, parameters);
                return values.FirstOrDefault();
            }

        }

        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            string query = "insert into Products (Title, Price, City, District, CoverImage, Address, Description, Type, DealOfTheDay, AdvertisementDate, ProductStatus, ProductCategory, EmployeeID) Values (@Title, @Price, @City, @District, @CoverImage, @Address, @Description, @Type, @DealOfTheDay, @AdvertisementDate, @ProductStatus, @ProductCategory, @EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDTO.Title);
            parameters.Add("@Price", createProductDTO.Price);
            parameters.Add("@City", createProductDTO.City);
            parameters.Add("@District", createProductDTO.District);
            parameters.Add("@CoverImage", createProductDTO.CoverImage);
            parameters.Add("@Address", createProductDTO.Address);
            parameters.Add("@Description", createProductDTO.Description);
            parameters.Add("@Type", createProductDTO.Type);
            parameters.Add("@DealOfTheDay", createProductDTO.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDTO.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDTO.ProductStatus);
            parameters.Add("@ProductCategory", createProductDTO.ProductCategory);
            parameters.Add("@EmployeeID", createProductDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetProductDetailByIdDTO> GetProductDetailByProductID(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDTO>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<List<ResultProductWithSearchListDTO>> GetProductWithSearchList(string searchKeyValue, int propertyCategoryID, string city)
        {
            string query = "Select * From Products Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryID And City=@city";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyCategoryID", propertyCategoryID);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}