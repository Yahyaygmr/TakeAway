using Newtonsoft.Json;
using TakeAway.WebUI.Dtos.CatalogDtos.ProductDtos;

namespace TakeAway.WebUI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMesage = await _httpClient.GetAsync("https://localhost:6001/api/products");

            var jsonData = await responseMesage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }
    }
}
