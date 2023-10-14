using Microsoft.Extensions.DependencyInjection;

namespace Services.DependencyResolvers.Autofac.CoreModule
{
    public interface IAspectModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
