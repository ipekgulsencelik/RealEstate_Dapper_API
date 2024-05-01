using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        
        public ProductDetailsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailByProductID")]
        public async Task<IActionResult> GetProductDetailByProductID(int id)
        {
            var values = await _productRepository.GetProductDetailByProductID(id);
            return Ok(values);
        }
    }
}