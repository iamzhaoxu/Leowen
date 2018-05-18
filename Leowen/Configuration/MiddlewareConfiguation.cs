using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leowen.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leowen.Configuration
{
    public class MiddlewareConfiguation : IAppConfiguable
    {
        public void Configure(IServiceCollection serviceCollection)
        {
           
        }

        public void Use(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CustomResponseMiddleware>();
        }
    }
}
