using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Services.DailyDiscountServices;

namespace TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyDiscountsController : ControllerBase
    {
        private readonly IDailyDiscountService _dailyDiscountService;

        public DailyDiscountsController(IDailyDiscountService DailyDiscountService)
        {
            _dailyDiscountService = DailyDiscountService;
        }
        [HttpGet]
        public async Task<IActionResult> DailyDiscountList()
        {
            var values = await _dailyDiscountService.GetAllDailyDiscountAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyDiscount(CreateDailyDiscountDto dto)
        {
            await _dailyDiscountService.CreateDailyDiscountAsync(dto);
            return Ok("İndirim Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDailyDiscount(string id)
        {
            await _dailyDiscountService.DeleteDailyDiscountAsync(id);
            return Ok("İndirim Silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyDiscount(string id)
        {
            var value = await _dailyDiscountService.GetByIdDailyDiscountAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDailyDiscount(UpdateDailyDiscountDto dto)
        {
            await _dailyDiscountService.UpdateDailyDiscountAsync(dto);
            return Ok("İndirim Güncellendi");
        }
    }
}
