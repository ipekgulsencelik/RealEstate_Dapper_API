using RealEstate_Dapper_API.DTOs.ServiceDTOs;

namespace RealEstate_Dapper_API.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync();
        void CreateService(CreateServiceDTO createServiceDTO);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDTO updateServiceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
