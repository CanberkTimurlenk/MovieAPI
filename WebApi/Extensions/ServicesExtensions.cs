using Repositories.Concrete.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;
using Services.Concrete;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
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


        public static void ConfigureServiceManager(this IServiceCollection services)

            => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)

            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IAwardRepository, AwardRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IAwardTypeRepository, AwardTypeRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IMovieDetailRepository, MovieDetailRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();

        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IAwardService, AwardManager>();
            services.AddScoped<IPersonService, PersonManager>();
            services.AddScoped<ILocationService, LocationManager>();
            services.AddScoped<IAwardTypeService, AwardTypeManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<IMovieDetailService, MovieDetailManager>();
            services.AddScoped<IActorService, ActorManager>();
            services.AddScoped<IDirectorService, DirectorManager>();

        }

    }

}
}
