using System.Security.Cryptography;
using System.Text;

namespace KonyvkolcsonzoRendszer.Services
{
    public class AuthService
    {
        public string GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string ComputeHmacHash256(string password, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
