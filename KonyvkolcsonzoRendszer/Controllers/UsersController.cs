using KonyvkolcsonzoRendszer.Services.Dtok;
using KonyvkolcsonzoRendszer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonyvkolcsonzoRendszer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Regist(LoginDto loginDto)
        {
            var response = await _user.PostRegist(loginDto);
            return Ok(response);
        }
    }
}
