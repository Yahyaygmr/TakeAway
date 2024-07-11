using TakeAway.Discount.Dtos.CouponDtos;

namespace TakeAway.Discount.Services.CouponServices
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetListCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto dto);
        Task UpdateCouponAsync(UpdateCouponDto dto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
