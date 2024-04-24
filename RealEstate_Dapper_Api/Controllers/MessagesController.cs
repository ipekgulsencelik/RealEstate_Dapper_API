using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("GetInBoxLast3MessageListByReceive")]
        public async Task<IActionResult> GetInBoxLast3MessageListByReceive(int id)
        {
            var values = await _messageRepository.GetInBoxLast3MessageListByReceive(id);
            return Ok(values);
        }
    }
}