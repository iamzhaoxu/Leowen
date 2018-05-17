using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Leowen.Controllers.Fibonacci
{
    public class FibonacciRequest
    {
        [BindRequired]
        [FromQuery(Name = "n")]
        public long Nth { get; set; }
    }
}
