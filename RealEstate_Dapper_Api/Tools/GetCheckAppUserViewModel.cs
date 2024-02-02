namespace RealEstate_Dapper_API.Tools
{
    public class GetCheckAppUserViewModel
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}