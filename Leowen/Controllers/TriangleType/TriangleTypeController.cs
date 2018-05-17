using Leowen.Business.Triangle;
using Microsoft.AspNetCore.Mvc;

namespace Leowen.Controllers.TriangleType
{
    public class TriangleTypeController : BaseApiController
    {
        private readonly ITriangleService _triangleService;

        public TriangleTypeController(ITriangleService triangleService)
        {
            _triangleService = triangleService;
        }

        [HttpGet]
        public IActionResult Get(TriangleTypeRequest request)
        {
            var name = _triangleService.GeTriangleType(request.EdageA, request.EdageB, request.EdageC).Name;
            return Ok(name);
        }
    }
}
