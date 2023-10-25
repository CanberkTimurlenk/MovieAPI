using Autofac.Extensions.DependencyInjection;
using Autofac;
using Services.DependencyResolvers.Autofac;

namespace WebApi.Extensions
{
    public static class HostBuilderExtensions
    {
        public static void ConfigureAutofac(this ConfigureHostBuilder host, IConfiguration configuration)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new ServiceModule());

            });
        }
    }
}
