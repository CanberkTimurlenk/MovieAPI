using Microsoft.Extensions.DependencyInjection;
using Services.Utilities.Ioc;
using Services.DependencyResolvers.Autofac.CoreModule;

namespace Services.DependencyResolvers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, IAspectModule[] modules)
        {
            foreach (var module in modules)
                module.Load(serviceCollection);

            return ServiceTool.Create(serviceCollection);
        }
    }
}
