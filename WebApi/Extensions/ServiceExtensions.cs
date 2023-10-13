using Repositories.Concrete.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;
using Services.Concrete;

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
    }
}
