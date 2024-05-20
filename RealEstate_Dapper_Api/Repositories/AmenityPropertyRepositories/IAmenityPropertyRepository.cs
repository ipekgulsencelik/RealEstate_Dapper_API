using RealEstate_Dapper_API.DTOs.AmenityPropertyDTOs;

namespace RealEstate_Dapper_API.Repositories.AmenityPropertyRepositories
{
    public interface IAmenityPropertyRepository
    {
        Task<List<ResultAmenityPropertyByTrueStatusDTO>> GetAmenityPropertyByTrueStatus(int id);
    }
}