using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Leowen.Controllers.TriangleType
{
    public class TriangleTypeRequest
    {
        [BindRequired]
        [FromQuery(Name = "a")]
        public int EdageA { get; set; }
        [BindRequired]
        [FromQuery(Name = "b")]
        public int EdageB { get; set; }
        [BindRequired]
        [FromQuery(Name = "c")]
        public int EdageC { get; set; } 
    }
}
