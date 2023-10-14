using Services.CrossCuttingConcerns.Caching.Abstract;
using Services.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Services.Utilities.Ioc;

namespace Services.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly string _key;
        private readonly ICacheService _cacheService;

        public CacheAspect(string key, int duration)
        {
            _key = key;
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();

        }

        public override async void Intercept(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType.GetGenericArguments()[0];

            var cachedValue = _cacheService.Get(_key, returnType);

            if (cachedValue is not null)
            {

                invocation.ReturnValue = typeof(Task)
                                                        .GetMethod("FromResult")
                                                        .MakeGenericMethod(returnType)
                                                        .Invoke(null, new object[] { cachedValue });

                return;

            }

            invocation.Proceed();

            var returnValue = await (dynamic)invocation.ReturnValue;

            TimeSpan span = TimeSpan.FromHours(_duration);

            _cacheService.Add(_key, returnValue, span);

        }
    }
}
