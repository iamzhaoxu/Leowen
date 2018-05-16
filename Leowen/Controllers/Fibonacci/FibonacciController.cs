using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Leowen.Business.Fibonacci;
using Leowen.Core.ErrorHandling;
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
            if (!request.N.HasValue)
            {
                throw new AppException(EventId.FibonacciBadRequest, "The argument n cannot be null.", "The request is invalid.")
                {
                    HttpStatusCode = HttpStatusCode.BadRequest
                };

            }
            var result = _fibonacciService.GetNthFibonacciNumber(request.N.Value);
            return Ok(result);
        }
    }
}
