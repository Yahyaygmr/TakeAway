using System.Text.Json;
using TakeAway.Basket.Dtos;
using TakeAway.Basket.Settings;

namespace TakeAway.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(userId);

            return JsonSerializer.Deserialize<BasketTotalDto>(basket);
        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
