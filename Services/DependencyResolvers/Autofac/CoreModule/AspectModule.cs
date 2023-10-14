using Microsoft.Extensions.DependencyInjection;
using Services.CrossCuttingConcerns.Caching.Abstract;
using Services.CrossCuttingConcerns.Caching.Concrete.Redis;

namespace Services.DependencyResolvers.Autofac.CoreModule
{
    public class AspectModule : IAspectModule
    {

        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICacheService, RedisCacheManager>();

        }

    }
}
