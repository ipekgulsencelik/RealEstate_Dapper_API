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

        public void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
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

        public Task<GetBottomGridDTO> GetBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            throw new NotImplementedException();
        }
    }
}
