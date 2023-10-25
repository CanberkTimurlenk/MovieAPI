using AspNetCoreRateLimit;
using Autofac;
using StackExchange.Redis;

namespace WebApi.DependencyResolvers.Autofac
{
    public class ApiModule : Module
    {
        public static IConfiguration Configuration { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DistributedCacheIpPolicyStore>().As<IIpPolicyStore>().SingleInstance();
            builder.RegisterType<DistributedCacheRateLimitCounterStore>().As<IRateLimitCounterStore>().SingleInstance();
            builder.RegisterType<RateLimitConfiguration>().As<IRateLimitConfiguration>().SingleInstance();

            var redisOptions = ConfigurationOptions.Parse(Configuration["ConnectionStrings:redisConn"]);
            builder.Register(provider => ConnectionMultiplexer.Connect(redisOptions)).As<IConnectionMultiplexer>().SingleInstance();
        }
    }
}
