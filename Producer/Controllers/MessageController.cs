using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.Services;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public MessageController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public IActionResult Send([FromBody] string message)
        {
            _messagePublisher.SendMessage(message);
            return Ok("Message ssent to RabbitMQ");
            
        }


    }
}
