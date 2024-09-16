using ETC_System_API.Models;

namespace ETC_System_API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}