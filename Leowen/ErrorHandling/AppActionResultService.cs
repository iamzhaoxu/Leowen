using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Leowen.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Leowen.ErrorHandling
{
    public class AppActionResultService : IAppActionResultService
    {
        private readonly ILoggerFactory _loggerFactory;

        public AppActionResultService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult GetActionResult(ExceptionContext context, IAppException appException)
        {
            var logger = _loggerFactory.CreateLogger<AppActionResultService>();
            var statusCode = appException.HttpStatusCode.HasValue
                ? (int)appException.HttpStatusCode.Value
                : (int)HttpStatusCode.InternalServerError;
            logger.LogError(appException.EventId, context.Exception, context.Exception.Message, appException.Parameters);
            var actionResult = appException.ReplyMessage != null
                ? (IActionResult)new JsonResult(new Error(appException.ReplyMessage))
                {
                    StatusCode = statusCode
                }
                : new StatusCodeResult(statusCode);
            return actionResult;
        }

        public IActionResult GetActionResult(ExceptionContext context)
        {
            return new JsonResult("A critical error happen during the call.")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
