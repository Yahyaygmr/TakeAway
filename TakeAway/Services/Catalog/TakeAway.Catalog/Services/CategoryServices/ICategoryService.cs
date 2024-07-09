using TakeAway.Catalog.Dtos.CategoryDtos;

namespace TakeAway.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto dto);
        Task UpdateCategoryAsync(UpdateCategoryDto dto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
