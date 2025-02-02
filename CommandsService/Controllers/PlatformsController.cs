using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        [HttpGet]
        public ActionResult TestInboundConnection()
        {
            return Ok("Inbound Test of Platforms Controller is good");
        }
    }
}
