using TakeAway.Catalog.Dtos.DailyDiscountDtos;

namespace TakeAway.Catalog.Services.DailyDiscountServices
{
    public interface IDailyDiscountService
    {
        Task<List<ResultDailyDiscountDto>> GetAllDailyDiscountAsync();
        Task CreateDailyDiscountAsync(CreateDailyDiscountDto dto);
        Task UpdateDailyDiscountAsync(UpdateDailyDiscountDto dto);
        Task DeleteDailyDiscountAsync(string id);
        Task<GetByIdDailyDiscountDto> GetByIdDailyDiscountAsync(string id);
    }
}
