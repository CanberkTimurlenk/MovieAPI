using Microsoft.Extensions.Caching.Distributed;
using Services.CrossCuttingConcerns.Caching.Abstract;
using System.Text;
using System.Text.Json;

namespace Services.CrossCuttingConcerns.Caching.Concrete.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            var jsonData = _cache.GetString(key);

            if (jsonData is null)
                return default;

            return JsonSerializer.Deserialize<T>(jsonData);

        }

        public async Task<object> Get(string key, Type type)
        {
            var jsonData = await _cache.GetStringAsync(key);

            if (jsonData is null)
                return default;

            return JsonSerializer.Deserialize(jsonData, type);
        }

        public void Add(string key, object data, TimeSpan cacheDuration)
        {


            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration
            };

            var jsonData = JsonSerializer.Serialize(data);
            _cache.SetString(key, jsonData, options);

        }
    }
}
