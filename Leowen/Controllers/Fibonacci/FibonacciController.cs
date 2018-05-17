using Leowen.Business.Fibonacci;
using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers.Fibonacci
{
    public class FibonacciController : BaseApiController
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        [HttpGet]
        public IActionResult Get(FibonacciRequest request)
        {
            var result = _fibonacciService.GetNthFibonacciNumber(request.Nth);
            return Ok(result);
        }
    }
}
