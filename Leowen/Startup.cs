using System.Collections.Generic;
using Leowen.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leowen
{
    public class Startup
    {
        private readonly IEnumerable<IAppConfiguable> _appConfiguables;
        public Startup(IConfiguration configuration, 
            IEnumerable<IAppConfiguable> appConfiguables)
        {
            Configuration = configuration;
            _appConfiguables = appConfiguables;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var appConfiguable in _appConfiguables)
            {
                appConfiguable.Configure(services);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            foreach (var appConfiguable in _appConfiguables)
            {
                appConfiguable.Use(app, env);
            }
        }
    }
}
