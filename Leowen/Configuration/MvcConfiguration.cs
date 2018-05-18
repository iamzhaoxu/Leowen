using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leowen.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leowen.Configuration
{
    public class MvcConfiguration : IAppConfiguable
    {
        private readonly ILoggerFactory _loggerFactory;

        public MvcConfiguration(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Configure(IServiceCollection services)
        {
            services.AddMvc(c =>
            {
                c.Filters.Add(new AppExceptionFilterAttribute(_loggerFactory));
                c.Filters.Add(new ValidateModelAttribute(_loggerFactory));
            });
        }

        public void Use(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }

    }
}
