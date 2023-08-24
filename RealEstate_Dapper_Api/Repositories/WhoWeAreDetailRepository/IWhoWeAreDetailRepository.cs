using RealEstate_Dapper_API.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_API.Repositories.WhoWeAreDetailRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO);
        Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
    }
}
