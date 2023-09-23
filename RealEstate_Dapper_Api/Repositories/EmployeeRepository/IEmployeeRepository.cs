using RealEstate_Dapper_API.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_API.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync();
        void CreateEmployee(CreateEmployeeDTO createEmployeeDTO);
        void DeleteEmployee(int id);
        void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }
}
