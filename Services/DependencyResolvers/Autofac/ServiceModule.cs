using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;
using Services.Abstract;
using Services.Concrete;
using Services.CrossCuttingConcerns.Caching.Abstract;
using Services.CrossCuttingConcerns.Caching.Concrete.Redis;
using Services.Utilities.Interceptors;

namespace Services.DependencyResolvers.Autofac
{
    public class ServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
          

            // Repositories
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AwardRepository>().As<IAwardRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AwardTypeRepository>().As<IAwardTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MovieDetailRepository>().As<IMovieDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ActorRepository>().As<IActorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorRepository>().As<IDirectorRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ServiceManager>().As<IServiceManager>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryManager>().As<IRepositoryManager>().InstancePerLifetimeScope();

            // Services
            builder.RegisterType<MovieManager>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<GenreManager>().As<IGenreService>().InstancePerLifetimeScope();
            builder.RegisterType<AwardManager>().As<IAwardService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonManager>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<LocationManager>().As<ILocationService>().InstancePerLifetimeScope();
            builder.RegisterType<AwardTypeManager>().As<IAwardTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageManager>().As<ILanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieDetailManager>().As<IMovieDetailService>().InstancePerLifetimeScope();
            builder.RegisterType<ActorManager>().As<IActorService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorManager>().As<IDirectorService>().InstancePerLifetimeScope();

            builder.RegisterType<RedisCacheManager>().As<ICacheService>().SingleInstance();

           
        }
    }
}
