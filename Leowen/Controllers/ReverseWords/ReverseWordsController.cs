using Leowen.Business.ReverseWords;
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
