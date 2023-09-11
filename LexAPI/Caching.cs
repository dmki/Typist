using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;

namespace LexAPI
{
    internal static class Caching
    {
        private static SystemClock systemClock;
        private static MemoryCacheOptions cacheOptions;
        public static MemoryCache _cache;

        public static void InitialiseCache()
        {
            systemClock = new SystemClock();
            cacheOptions = new MemoryCacheOptions();
            cacheOptions.Clock = systemClock;
            cacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
            _cache = new MemoryCache(cacheOptions);
        }

        public static void ClearCache(string cacheName)
        {
            if (_cache == null) InitialiseCache();
            _cache.Remove(cacheName);
            //HttpContext.Current.Cache.Remove(cacheName);
        }
        public static void AddAbsoluteCache(object Object, int minutes, string cacheName)//, CacheItemPriority priority = CacheItemPriority.Normal
        {
            cacheName = cacheName.ToUpperInvariant();
            _cache.Set(cacheName, Object, DateTimeOffset.Now.AddMinutes(minutes));
        }

        public static void AddAbsoluteCache2(object Object, int seconds, string cacheName)
        {
            cacheName = cacheName.ToUpperInvariant();
            _cache.Set(cacheName, Object, DateTimeOffset.Now.AddSeconds(seconds));
        }

        public static object GetCache(string key)
        {
            //return HttpContext.Current.Cache[key.ToUpper()];
            return _cache.Get(key.ToUpperInvariant());
        }

        public static string GetCacheString(string key, string defaultValue = "")
        {
            var result = GetCache(key);
            return result == null ? defaultValue : Convert.ToString(result);
        }

        public static bool IsCacheNull(string key)
        {
            return (GetCache(key) == null);
        }
    }
}
