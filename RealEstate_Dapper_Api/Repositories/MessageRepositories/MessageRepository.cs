using Dapper;
using RealEstate_Dapper_API.DTOs.MessageDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInoxMessageDTO>> GetInBoxLast3MessageListByReceive(int id)
        {
            string query = "Select Top(3) * From Messages Where Receiver=@receiverID Order By MessageID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}