using Microsoft.AspNetCore.Mvc;

namespace ChannelsImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> Log([FromBody] string message)
        {
            await _logService.LogAsync(message);
            return Ok("Log added to the channel.");
        }
    }
}
