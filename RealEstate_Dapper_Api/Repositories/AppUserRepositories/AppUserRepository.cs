using Dapper;
using RealEstate_Dapper_API.DTOs.AppUserDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDTO> GetAppUserByProductID(int id)
        {
            string query = "Select * From AppUser Where UserID=@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDTO>(query, parameters);
                return values;
            }
        }
    }
}