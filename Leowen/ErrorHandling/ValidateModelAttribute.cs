using System.Net;
using Leowen.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Leowen.ErrorHandling
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILoggerFactory _loggerFactory;

        public ValidateModelAttribute(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = _loggerFactory.CreateLogger<ValidateModelAttribute>();
            if (!context.ModelState.IsValid)
            {
                logger.LogError((int)EventCode.FibonacciBadRequest, "The request is invalid.");
                context.Result = new JsonResult(new Error("The request is invalid."))
                {
                    StatusCode = (int) HttpStatusCode.BadRequest
                };
            }
        }
    }
}
