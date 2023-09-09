using RealEstate_Dapper_API.DTOs.TestimonialDTOs;

namespace RealEstate_Dapper_API.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync();
    }
}
