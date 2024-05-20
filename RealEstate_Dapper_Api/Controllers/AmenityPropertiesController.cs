using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.AmenityPropertyRepositories;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityPropertiesController : ControllerBase
    {
        private readonly IAmenityPropertyRepository _repository;

        public AmenityPropertiesController(IAmenityPropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAmenityPropertyByTrueStatus(int id)
        {
            var values = await _repository.GetAmenityPropertyByTrueStatus(id);
            return Ok(values);
        }
    }
}