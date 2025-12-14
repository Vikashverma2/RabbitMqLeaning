using Consumer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumeController : ControllerBase
    {
        

        private readonly IMessageConsumer _messageConsumer;

        public ConsumeController(IMessageConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }

        [HttpGet]
        public async Task<IActionResult> Consume()
        {
            await _messageConsumer.StartConsuming();
            return Ok("Started consuming messages from RabbitMQ");
        }
    }
}
