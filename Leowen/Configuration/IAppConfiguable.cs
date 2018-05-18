using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leowen.Configuration
{
    public interface IAppConfiguable
    {
        void Configure(IServiceCollection serviceCollection);
        void Use(IApplicationBuilder app, IHostingEnvironment env);
    }
}
