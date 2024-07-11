using Dapper;
using Microsoft.EntityFrameworkCore;
using TakeAway.Discount.Context;
using TakeAway.Discount.Dtos.CouponDtos;

namespace TakeAway.Discount.Services.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly DiscountContext _discountContext;

        public CouponService(DiscountContext discountContext)
        {
            _discountContext = discountContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto dto)
        {
            string query = "Insert Into Coupons (Code,Rate,IsActive) values (@code,@rate,@isActive)";

            var parameters = new DynamicParameters();
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);

            var connection = _discountContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons Where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            var connection = _discountContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            var query = "Select * From Coupons Where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            var connection = _discountContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
            return values;
        }

        public async Task<List<ResultCouponDto>> GetListCouponsAsync()
        {
            var query = "Select * From Coupons";

            var connection = _discountContext.CreateConnection();
            var values = await connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }

        public async Task UpdateCouponAsync(UpdateCouponDto dto)
        {
            string query = "Update Coupons Set Code=@code Rate=@rate IsActive=@isActive Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);
            parameters.Add("@couponId", dto.CouponId);

            var connection = _discountContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
