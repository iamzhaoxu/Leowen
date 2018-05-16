using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leowen.Business;
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
        }
    }
}
