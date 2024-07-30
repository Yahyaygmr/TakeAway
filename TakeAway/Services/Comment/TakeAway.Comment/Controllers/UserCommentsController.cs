using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Comment.Dtos;
using TakeAway.Comment.Services;

namespace TakeAway.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentsController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var values = await _userCommentService.GetAllCommentsAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateUserCommentDto dto)
        {
            await _userCommentService.CreateUserCommentAsync(dto);
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _userCommentService.DeleteUserCommentAsync(id);
            return Ok("Silme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateUserCommentDto dto)
        {
            await _userCommentService.UpdateUserCommentAsync(dto);
            return Ok("Güncelleme işlemi başarılı.");
        }
        [HttpGet("GetComment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var values = await _userCommentService.GetUserCommentByIdAsync(id);
            return Ok(values);
        }
        [HttpGet("GetCommentsByUserId/{id}")]
        public async Task<IActionResult> GetCommentsByUserId(string id)
        {
            var values = await _userCommentService.GetCommentsByProduct(id);
            return Ok(values);
        }
    }
}
