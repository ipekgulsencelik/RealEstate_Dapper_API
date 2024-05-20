using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.AmenityPropertyDTOs;

namespace RealEstate_Dapper_API.Repositories.AmenityPropertyRepositories
{
    public class AmenityPropertyRepository : IAmenityPropertyRepository
    {
        private readonly Context _context;

        public AmenityPropertyRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAmenityPropertyByTrueStatusDTO>> GetAmenityPropertyByTrueStatus(int id)
        {
            string query = "Select AmenityPropertyID, Title From AmenityProperty Inner Join Amenities On Amenities.AmenityID=AmenityProperty.AmenityID Where ProductID=@propertyID And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAmenityPropertyByTrueStatusDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}