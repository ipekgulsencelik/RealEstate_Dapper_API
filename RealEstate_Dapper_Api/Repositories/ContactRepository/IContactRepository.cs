using RealEstate_Dapper_API.DTOs.ContactDTOs;

namespace RealEstate_Dapper_API.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task<List<Last4ContactResultDTO>> GetLast4Contact();
        void CreateContact(CreateContactDTO createContactDTO);
        void DeleteContact(int id);
        Task<GetByIDContactDTO> GetContact(int id);
    }
}       