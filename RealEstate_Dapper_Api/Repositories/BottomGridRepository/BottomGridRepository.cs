using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.BottomGridDTOs;

namespace RealEstate_Dapper_API.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            string query = "Insert Into BottomGrids (Icon,Title,Description) Values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createBottomGridDTO.Icon);
            parameters.Add("@title", createBottomGridDTO.Title);
            parameters.Add("@description", createBottomGridDTO.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrids Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrids";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDTO> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrids Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            string query = "Update BottomGrids Set Icon=@icon,Title=@title,Description=@description Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDTO.Icon);
            parameters.Add("@title", updateBottomGridDTO.Title);
            parameters.Add("@description", updateBottomGridDTO.Description);
            parameters.Add("@bottomGridID", updateBottomGridDTO.BottomGridID);
            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}