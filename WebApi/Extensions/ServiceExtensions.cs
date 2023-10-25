using Repositories.Concrete.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DependencyResolvers.Autofac.CoreModule;
using Services.DependencyResolvers.Extensions;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)

            => services.AddDbContext<MovieContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("redisConn");
                options.InstanceName = "MovieCatalog";
            });
        }

        public static void ConfigureAspects(this IServiceCollection services)
        {
            services.AddDependencyResolvers(new IAspectModule[] { new AspectModule() });
        }
    }
}
