﻿namespace RealEstate_Dapper_API.DTOs.MessageDTOs
{
    public class ResultInoxMessageDTO
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public string UserImageURL { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}