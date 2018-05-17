using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers
{
    public class HealthController : BaseApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Success";
        }
    }
}
