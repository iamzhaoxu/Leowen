using Microsoft.Extensions.DependencyInjection;

namespace Leowen.Core.DependencyInjection
{
    public interface IDependecyModule
    {
        void Register(IServiceCollection serviceCollection);
    }
}
