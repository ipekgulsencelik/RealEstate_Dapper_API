using RealEstate_Dapper_API.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_API.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDTO>> GetAllToDoListAsync();
        void CreateToDoList(CreateToDoListDTO ToDoListDTO);
        void DeleteToDoList(int id);
        void UpdateToDoList(UpdateToDoListDTO ToDoListDTO);
        Task<GetByIDToDoListDTO> GetToDoList(int id);
    }
}   