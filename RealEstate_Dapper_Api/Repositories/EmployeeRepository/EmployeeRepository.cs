using RealEstate_Dapper_API.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_API.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
