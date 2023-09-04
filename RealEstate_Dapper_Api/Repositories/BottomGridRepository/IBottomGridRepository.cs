using RealEstate_Dapper_API.DTOs.BottomGridDTOs;

namespace RealEstate_Dapper_API.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO);
        Task<GetBottomGridDTO> GetBottomGrid(int id);
    }
}
