using TakeAway.Basket.Dtos;

namespace TakeAway.Basket.Services
{
    public class BasketService : IBasketService
    {
        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketTotalDto> GetBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveBasket(BasketTotalDto basket)
        {
            throw new NotImplementedException();
        }
    }
}
