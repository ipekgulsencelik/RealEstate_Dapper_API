namespace RealEstate_Dapper_UI.DTOs.AppUserDTOs
{
    public class GetAppUserByProductIdDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImageURL { get; set; }
    }
}