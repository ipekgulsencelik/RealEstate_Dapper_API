﻿namespace RealEstate_Dapper_UI.DTOs.ContactDTOs
{
    public class Last4ContactResultDTO
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}