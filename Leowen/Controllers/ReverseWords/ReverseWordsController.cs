using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Leowen.Business.Fibonacci;
using Leowen.Business.ReverseWords;
using Leowen.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers.ReverseWords
{
    public class ReverseWordsController : BaseApiController
    {
        private readonly IReverseWordsService _reverseWordsService;

        public ReverseWordsController(IReverseWordsService reverseWordsService)
        {
            _reverseWordsService = reverseWordsService;
        }

        [HttpGet]
        public IActionResult Get(ReverseWordsRequest request)
        {
            var result = _reverseWordsService.Reverse(request.Sentence);
            return Ok(result);
        }
    }
}
