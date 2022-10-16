using FilmManagement.Core.Entities;
using FilmManagement.Core.Models.User.Response;
using System.Threading.Tasks;

namespace FilmManagement.Core.Interfaces.UserManagement
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(string username, string password);
        LoginResponse CreateTokenResponse(User user);
    }
}
