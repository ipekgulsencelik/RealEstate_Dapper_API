using Dapper;
using RealEstate_Dapper_API.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocations";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }
    }
}
