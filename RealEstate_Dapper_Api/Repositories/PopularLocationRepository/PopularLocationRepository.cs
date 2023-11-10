using Dapper;
using RealEstate_Dapper_API.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.ServiceDTOs;

namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO)
        {
            string query = "Insert Into PopularLocations (CityName,ImageURL) Values (@cityName,@imageURL)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDTO.CityName);
            parameters.Add("@imageURL", createPopularLocationDTO.ImageURL);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocations Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllPopularLocation()
        {
            string query = "Select * From PopularLocations";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetPopularLocationDTO> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocations Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetPopularLocationDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO)
        {
            string query = "Update PopularLocations Set CityName=@cityName, ImageURL=@imageURL Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDTO.CityName);
            parameters.Add("@imageURL", updatePopularLocationDTO.ImageURL);
            parameters.Add("@locationID", updatePopularLocationDTO.LocationID);
            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}