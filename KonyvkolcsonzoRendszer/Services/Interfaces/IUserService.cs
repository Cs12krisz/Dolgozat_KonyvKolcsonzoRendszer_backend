using KonyvkolcsonzoRendszer.Services.Dtok;

namespace KonyvkolcsonzoRendszer.Services.Interfaces
{
    public interface IUserService
    {
        Task<object> PostRegist(LoginDto loginDto);
    }
}
