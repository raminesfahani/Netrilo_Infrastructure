using Newtonsoft.Json;
using System;
using static Infrastructure.Databases.Redis.ServiceRegistration;
using Netrilo.Infrastructure.Common.Persistence.NoSql.Redis;

namespace Netrilo.Infrastructure.Common.Persistence.NoSql.Redis.Repository
{
    public class RedisRepository : IRedisRepository
    {
        private StackExchange.Redis.IDatabase _db;
        private readonly IRedisSettings _redisSettings;
        public RedisRepository(IRedisSettings redisSettings)
        {
            _redisSettings = redisSettings;
            ConfigureRedis(_redisSettings);
        }
        private void ConfigureRedis(IRedisSettings redisSettings)
        {
            _db = ConnectionHelper.Connection(redisSettings).GetDatabase();
        }
        public async Task<T?> GetData<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }
        public async Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = await _db.StringSetAsync(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
        public async Task<object> RemoveData(string key)
        {
            bool _isKeyExist = await _db.KeyExistsAsync(key);
            if (_isKeyExist == true)
            {
                return await _db.KeyDeleteAsync(key);
            }
            return false;
        }
    }
}
