using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.ProductDtos;
using TakeAway.Catalog.Services.ProductServices;

namespace TakeAway.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return Ok("Ürün Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün Silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return Ok("Ürün Güncellendi");
        }
    }
}
