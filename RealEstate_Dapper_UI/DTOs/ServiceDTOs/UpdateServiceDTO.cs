﻿namespace RealEstate_Dapper_UI.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}