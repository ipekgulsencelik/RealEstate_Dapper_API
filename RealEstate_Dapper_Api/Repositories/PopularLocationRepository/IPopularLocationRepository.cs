using RealEstate_Dapper_API.DTOs.PopularLocationDTOs;

namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync();
    }
}
