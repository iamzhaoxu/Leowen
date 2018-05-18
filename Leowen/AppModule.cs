using Leowen.Business;
using Leowen.Configuration;
using Leowen.Core;
using Leowen.Core.DependencyInjection;
using Leowen.ErrorHandling;
using Microsoft.Extensions.DependencyInjection;

namespace Leowen
{
    public class AppModule : IDependecyModule
    {
        public void Register(IServiceCollection serviceCollection)
        {
            new CoreModule().Register(serviceCollection);
            new BusinessServicesModule().Register(serviceCollection);
            serviceCollection.AddSingleton<IAppActionResultService, AppActionResultService>();
            serviceCollection.AddTransient<IAppConfiguable, MvcConfiguration>();
            serviceCollection.AddTransient<IAppConfiguable, MiddlewareConfiguation>();
            serviceCollection.AddTransient<IAppConfiguable, SwaggerConfiguration>();
        }
    }
}
