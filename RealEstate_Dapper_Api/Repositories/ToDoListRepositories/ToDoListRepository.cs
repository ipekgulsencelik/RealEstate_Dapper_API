﻿using RealEstate_Dapper_API.DTOs.ToDoListDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_API.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;
        
        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        
        public void CreateToDoList(CreateToDoListDTO ToDoListDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDTO>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDTO>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDToDoListDTO> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDoList(UpdateToDoListDTO ToDoListDTO)
        {
            throw new NotImplementedException();
        }
    }
}