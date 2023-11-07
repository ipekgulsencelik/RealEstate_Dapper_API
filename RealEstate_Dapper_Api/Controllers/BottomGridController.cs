using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.DTOs.BottomGridDTOs;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDTO);
            return Ok("Veri Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Veri Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDTO);
            return Ok("Veri Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}