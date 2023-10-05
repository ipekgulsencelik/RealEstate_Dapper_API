using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_API.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string query = "insert into Employees (Name, Title, Mail, PhoneNumber, ImageURL, Status) values (@name, @title, @mail, @phoneNumber, @imageURL, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDTO.Name);
            parameters.Add("@title", createEmployeeDTO.Title);
            parameters.Add("@mail", createEmployeeDTO.Mail);
            parameters.Add("@phoneNumber", createEmployeeDTO.PhoneNumber);
            parameters.Add("@imageURL", createEmployeeDTO.ImageURL);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employees Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employees";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            string query = "Select * From Employees Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            string query = "Update Employees Set Name=@name, Title=@title, Mail=@mail, PhoneNumber=@phoneNumber, ImageURL=@imageURL, Status=@status Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDTO.Name);
            parameters.Add("@title", updateEmployeeDTO.Title);
            parameters.Add("@mail", updateEmployeeDTO.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDTO.PhoneNumber);
            parameters.Add("@imageURL", updateEmployeeDTO.ImageURL);
            parameters.Add("@status", true);
            parameters.Add("@employeeID", updateEmployeeDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}