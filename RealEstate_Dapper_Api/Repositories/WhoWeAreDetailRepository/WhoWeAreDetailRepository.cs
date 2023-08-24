using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_API.Repositories.WhoWeAreDetailRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
        {
            string query = "insert into WhoWeAreDetails (Title,Subtitle,Description,SubDescription) values (@title,@subTitle,@description,@subDescription)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDTO.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDTO.Subtitle);
            parameters.Add("@description", createWhoWeAreDetailDTO.Description);
            parameters.Add("@subDescription", createWhoWeAreDetailDTO.SubDescription);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetails Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetails Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO)
        {
            string query = "Update WhoWeAreDetails Set Title=@title,Subtitle=@subTitle,Description=@description,SubDescription=@subDescription where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDTO.Title);
            parameters.Add("@Subtitle", updateWhoWeAreDetailDTO.Subtitle);
            parameters.Add("@description", updateWhoWeAreDetailDTO.Description);
            parameters.Add("@subDescription", updateWhoWeAreDetailDTO.SubDescription);
            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDTO.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}