using Leowen.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leowen.ErrorHandling
{
    public interface IAppActionResultService
    {
        IActionResult GetActionResult(ExceptionContext context, IAppException appException);
        IActionResult GetActionResult(ExceptionContext context);
    }
}