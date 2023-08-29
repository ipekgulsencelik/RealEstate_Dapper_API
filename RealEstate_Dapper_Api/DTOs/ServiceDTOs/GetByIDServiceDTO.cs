namespace RealEstate_Dapper_API.DTOs.ServiceDTOs
{
    public class GetByIDServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
