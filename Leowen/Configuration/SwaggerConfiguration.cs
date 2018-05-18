using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leowen.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Leowen.Configuration
{
    public class SwaggerConfiguration : IAppConfiguable
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Redify Test API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Email = "iamzhaoxu@gmail.com",
                        Name = "Xu Zhao"
                    }
                });
            });
        }

        public void Use(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Redify Test API V1");
            });
        }
    }
}
