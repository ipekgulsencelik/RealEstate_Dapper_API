using RealEstate_Dapper_API.DTOs.AppUserDTOs;

namespace RealEstate_Dapper_API.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDTO> GetAppUserByProductID(int id);
    }
}