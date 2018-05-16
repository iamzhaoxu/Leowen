using System.ComponentModel.DataAnnotations;

namespace Leowen.Controllers.ReverseWords
{
    public class ReverseWordsRequest
    {
        [Required]
        public string Sentence { get; set; }
    }
}
