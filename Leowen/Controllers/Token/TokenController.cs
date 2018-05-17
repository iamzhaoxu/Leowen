using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers.Token
{
    public class TokenController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("8c6f3d1c-3942-489c-af09-7581d86c80b9");
        }
    }
}
