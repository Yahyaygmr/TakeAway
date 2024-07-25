using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;
using TakeAway.IdentityServer.Data;
using TakeAway.IdentityServer.Dtos;
using TakeAway.IdentityServer.Models;

namespace TakeAway.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = _userManager.Users.ToList();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(CreateUserRegisterDto dto)
        {
            var values = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
            };
            var result = await _userManager.CreateAsync(values, dto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Kaydı Başarılı");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
