using RealEstate_Dapper_API.DTOs.PopularLocationDTOs;

namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocation();
        void CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO);
        Task<GetPopularLocationDTO> GetPopularLocation(int id);
    }
}