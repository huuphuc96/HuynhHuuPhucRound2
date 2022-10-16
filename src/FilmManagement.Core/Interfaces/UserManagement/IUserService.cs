using FilmManagement.Core.Entities;
using FilmManagement.Core.Models.User.Request;
using FilmManagement.Core.Models.User.Response;
using System.Threading.Tasks;

namespace FilmManagement.Core.Interfaces.UserManagement
{
    public interface IUserService : IService<User>
    {
        Task<User> FindByIdAsync(string id);
        Task<User> FindByUserNameAsync(string username);
        Task<UserModel> AddUserAsync(UserCreateModelRequest request);
        Task<User> FindByEmailAsync(string email);
        
        //Task<string> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task InitAdminAccountAsync();
    }
}
