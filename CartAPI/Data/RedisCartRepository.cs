using CartAPI.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text.Json.Serialization;

namespace CartAPI.Data
{
    public class RedisCartRepository : ICartRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public RedisCartRepository(ConnectionMultiplexer redis) 
        { 
            _redis = redis;
            _database = redis.GetDatabase();
        }
        public Task<bool> DeleteCartAsync(string cartId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartAsync(string cartId)
        {
           var data = await _database.StringGetAsync(cartId); 
           if (data.IsNullOrEmpty)
            {
                return null; 
            }
           JsonConvert
        }

        public Task<Cart> UpdateCartAsync(Cart basket)
        {
            throw new NotImplementedException();
        }
    }

}
