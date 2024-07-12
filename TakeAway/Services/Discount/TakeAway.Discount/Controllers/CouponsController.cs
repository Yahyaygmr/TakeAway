using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Discount.Dtos.CouponDtos;
using TakeAway.Discount.Services.CouponServices;

namespace TakeAway.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _couponService.GetListCouponsAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto dto)
        {
            await _couponService.CreateCouponAsync(dto);
            return Ok("Kupon Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto dto)
        {
            await _couponService.UpdateCouponAsync(dto);
            return Ok("Kupon Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon(int id)
        {
            var value = await _couponService.GetByIdCouponAsync(id);
            return Ok(value);
        }
    }
}
