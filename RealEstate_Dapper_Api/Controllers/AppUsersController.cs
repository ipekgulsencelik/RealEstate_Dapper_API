using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;
        
        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUserByProductID(int id)
        {
            var value = await _appUserRepository.GetAppUserByProductID(id);
            return Ok(value);
        }
    }
}