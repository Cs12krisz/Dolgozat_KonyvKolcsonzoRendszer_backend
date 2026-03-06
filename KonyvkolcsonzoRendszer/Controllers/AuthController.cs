using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services;
using KonyvkolcsonzoRendszer.Services.Dtok;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace KonyvkolcsonzoRendszer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KonyvKolcsonzoContext _context;
        private readonly GenerateToken generateToken;
        private readonly AuthService authService;


        public AuthController(KonyvKolcsonzoContext context, GenerateToken generateToken, AuthService authService)
        {
            this.generateToken = generateToken;
            _context = context;
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto) 
        {
            if (loginDto != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username);

                if (user != null && user.PasswordHash == authService.ComputeHmacHash256(loginDto.Password, user.Salt)) {
                    return Ok(new { Token = generateToken.Token(user.Username, user.Id) });
                }

            }
            return BadRequest();
        }

    }
}
