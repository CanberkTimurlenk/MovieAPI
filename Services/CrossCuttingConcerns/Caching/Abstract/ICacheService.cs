namespace Services.CrossCuttingConcerns.Caching.Abstract
{
    public interface ICacheService
    {
        T Get<T>(string cacheKey);
        void Add(string key, object data, TimeSpan cacheDuration);
        object Get(string key, Type type);
    }
}
