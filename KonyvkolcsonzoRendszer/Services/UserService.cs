using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;
using KonyvkolcsonzoRendszer.Services.Interfaces;

namespace KonyvkolcsonzoRendszer.Services
{
    public class UserService : IUserService
    {
        private readonly KonyvKolcsonzoContext _context;
        private readonly GenerateToken generateToken;
        private readonly AuthService authService;

        public UserService(KonyvKolcsonzoContext context, GenerateToken generateToken, AuthService authService)
        {
            _context = context;
            this.generateToken = generateToken;
            this.authService = authService;
        }

        public async Task<object> PostRegist(LoginDto loginDto)
        {
            if (loginDto != null)
            {
                string usersSalt = authService.GenerateSalt();
                User user = new User()
                {
                    Username = loginDto.Username,
                    Salt = usersSalt,
                    PasswordHash = authService.ComputeHmacHash256(loginDto.Password, usersSalt),
                    Email = null,
                    Role = null
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return new { Value = user, Message = "Sikeres regisztráció" };
            }
            return "Sikertelen regisztráció";
        }
    }
}
