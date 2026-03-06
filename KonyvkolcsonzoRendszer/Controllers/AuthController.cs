using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace KonyvkolcsonzoRendszer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KonyvKolcsonzoContext _context;

        public AuthController(KonyvKolcsonzoContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto) 
        {
            if (loginDto != null) {

                if (loginDto.Password != null) { }    
            }
            return BadRequest();
        }

    }
}
