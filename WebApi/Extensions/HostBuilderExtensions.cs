using Autofac.Extensions.DependencyInjection;
using Autofac;
using Services.DependencyResolvers.Autofac;
using WebApi.DependencyResolvers.Autofac;

namespace WebApi.Extensions
{
    public static class HostBuilderExtensions
    {
        public static void ConfigureAutofac(this ConfigureHostBuilder host, IConfiguration configuration)
        {
            ApiModule.Configuration = configuration;
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new ServiceModule());
                builder.RegisterModule(new ApiModule());

            });
        }
    }
}
