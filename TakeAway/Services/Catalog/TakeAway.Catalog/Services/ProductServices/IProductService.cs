using TakeAway.Catalog.Dtos.ProductDtos;

namespace TakeAway.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto dto);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
