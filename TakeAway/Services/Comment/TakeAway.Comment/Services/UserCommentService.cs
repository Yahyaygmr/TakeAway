using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.DAL.Context;
using TakeAway.Comment.DAL.Etities;
using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public class UserCommentService : IUserCommentService
    {
        private readonly CommentContext _context;
        private readonly IMapper _mapper;

        public UserCommentService(CommentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto)
        {
            var result = _mapper.Map<UserComment>(userCommentDto);

            await _context.UserComments.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var values = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserCommentDto>> GetAllCommentsAsync()
        {
            var values = await _context.UserComments.ToListAsync();
            var result = _mapper.Map<List<ResultUserCommentDto>>(values);
            return result;

        }

        public async Task<List<ResultUserCommentDto>> GetCommentsByProduct(string productId)
        {
            var values = await _context.UserComments.Where(x => x.ProductId == productId).ToListAsync();
            var result = _mapper.Map<List<ResultUserCommentDto>>(values);
            return result;
        }

        public async Task<GetUserCommentByIdDto> GetUserCommentByIdAsync(int id)
        {
            var values = await _context.UserComments.FindAsync(id);
            var result = _mapper.Map<GetUserCommentByIdDto>(values);
            return result;
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto userCommentDto)
        {
            var result = _mapper.Map<UserComment>(userCommentDto);
            _context.UserComments.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}
