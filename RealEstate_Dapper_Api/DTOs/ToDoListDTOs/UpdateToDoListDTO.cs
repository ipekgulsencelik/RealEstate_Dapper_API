﻿namespace RealEstate_Dapper_API.DTOs.ToDoListDTOs
{
    public class UpdateToDoListDTO
    {
        public int ToDoListID { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}