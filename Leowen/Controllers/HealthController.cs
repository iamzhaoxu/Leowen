using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
