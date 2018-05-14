using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Leowen.Controllers.Model;
using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers
{
    public class FibonacciController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get(FibonacciRequest request)
        {
            if (!request.N.HasValue)
            {
                return BadRequest(new Error("The request is invalid."));

            }
            var n = Math.Abs(request.N.Value);
            var result = GetFibonacciNumber(n);
            if (request.N.Value < 0 && request.N.Value % 2 == 0)
            {
                result = result * -1;
            }
            return Ok(result);
        }

        public static long GetFibonacciNumber(long n)
        {
            var f0 = 0;
            var f1 = 1;
            for (var i = 0; i < n; i++)
            {
                var tmp = f0 + f1;
                f0 = f1;
                f1 = tmp;
            }
            return f0;
        }
    }

    public class FibonacciRequest
    {
        [Required]
        public long? N { get; set; }
    }
}
