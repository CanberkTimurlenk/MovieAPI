using Repositories.Concrete.EFCore.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Services.Concrete;
using Services.Abstract;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)

            => services.AddDbContext<MovieContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureServiceManager(this IServiceCollection services)

            => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)

            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();

        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieManager>();

        }

    }



}
