using System.ComponentModel.DataAnnotations;

namespace Leowen.Controllers.Fibonacci
{
    public class FibonacciRequest
    {
        [Required]
        public long? N { get; set; }
    }
}
