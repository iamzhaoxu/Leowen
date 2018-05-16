using System.Net;
using Leowen.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Leowen.ErrorHandling
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IAppActionResultService _appActionResultService;

        public AppExceptionFilterAttribute(ILoggerFactory loggerFactory):
            this(loggerFactory, new AppActionResultService(loggerFactory))
        {

        }

        public AppExceptionFilterAttribute(ILoggerFactory loggerFactory, IAppActionResultService appActionResultService)
        {
            _loggerFactory = loggerFactory;
            _appActionResultService = appActionResultService;
        }
        //
        public override void OnException(ExceptionContext context)
        {
            var logger = _loggerFactory.CreateLogger<AppExceptionFilterAttribute>();
            base.OnException(context);
            if (context.Exception is IAppException appException)
            {
                var actionResult = _appActionResultService.GetActionResult(context, appException);
                context.Result = actionResult;
                return;
            }
            logger.LogCritical(context.Exception,context.Exception.Message);
            context.Result = _appActionResultService.GetActionResult(context);
        }
    }
}
