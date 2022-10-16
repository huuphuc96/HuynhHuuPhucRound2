using FilmManagement.Core.Models.User.Response;

namespace FilmManagement.Core.Interfaces.UserManagement
{
    public interface ITokenService
    {
        TokenResponse CreateTokenBearer(string userId);
    }
}
