using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using StackExchange.Redis;

using Atlantic.Api.Services.Interfaces;

using Constants = Atlantic.Api.Models.Constants;

namespace Atlantic.Api.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var response = await db.StringGetAsync(key);

            if (string.IsNullOrWhiteSpace(response.ToString()))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(response.ToString());
        }

        public async Task SetAsync<T>(string key, T document, bool always = false)
        {
            var db = _redis.GetDatabase();
            var documentSerialized = JsonConvert.SerializeObject(document);

            if (always)
            {
                await db.StringSetAsync(key, documentSerialized, when: When.Always);
                return;
            }

            await db.StringSetAsync(key, documentSerialized, TimeSpan.FromDays(Constants.REDIS_DAYS));
        }

        public async Task SetWithTimeAsync<T>(string key, T document)
        {
            var db = _redis.GetDatabase();
            var documentSerialized = JsonConvert.SerializeObject(document);
            await db.StringSetAsync(key, documentSerialized, TimeSpan.FromDays(Constants.REDIS_TRACED_DAYS));
        }
                               
        public List<string> GetAllKeysByPattern(string pattern)
        { 
            var server = _redis.GetServers().First();
            var patternKeys = pattern + Constants.ASTERISK;

            var keys = server.Keys(pattern: patternKeys).Cast<string>().ToList();
            return keys;
        }
    }
}
