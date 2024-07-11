using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.SliderDtos;
using TakeAway.Catalog.Services.SliderServices;

namespace TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService SliderService)
        {
            _sliderService = SliderService;
        }
        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto dto)
        {
            await _sliderService.CreateSliderAsync(dto);
            return Ok("Slider Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return Ok("Slider Silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(string id)
        {
            var value = await _sliderService.GetByIdSliderAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto dto)
        {
            await _sliderService.UpdateSliderAsync(dto);
            return Ok("Slider Güncellendi");
        }
    }
}
