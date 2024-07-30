using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDto>> GetAllCommentsAsync();
        Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto userCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<GetUserCommentByIdDto> GetUserCommentByIdAsync(int id);
        Task<List<ResultUserCommentDto>> GetCommentsByProduct(string productId);
    }
}
