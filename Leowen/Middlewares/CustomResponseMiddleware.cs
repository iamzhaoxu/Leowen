using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Leowen.Middlewares
{
    public class CustomResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("pragma", "no-cache");
            return this._next(context);
        }
    }
}
