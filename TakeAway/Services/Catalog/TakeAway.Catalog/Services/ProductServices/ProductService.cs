using TakeAway.Catalog.Dtos.ProductDtos;

namespace TakeAway.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        public Task CreateProductAsync(CreateProductDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultProductDto>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
