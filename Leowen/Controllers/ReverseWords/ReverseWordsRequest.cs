using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Leowen.Controllers.ReverseWords
{
    public class ReverseWordsRequest
    {
        [BindRequired]
        [FromQuery(Name = "sentence")]
        public string Sentence { get; set; }
    }
}
