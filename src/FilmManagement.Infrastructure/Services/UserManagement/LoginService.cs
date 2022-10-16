using FilmManagement.Core.Constants;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Helpers;
using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.Models.User.Response;
using FilmManagement.Core.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Services.UserManagement
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService tokenService;
        private readonly IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="repository"></param>
        public LoginService(ITokenService tokenService
            , IRepository repository
        )
        {
            this.tokenService = tokenService;
            this.repository = repository;
        }

        /// <summary>
        /// Login async service
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var user = await repository.Query<User>(x => (x.Username == username || x.Email == username) && !x.IsDeleted).FirstOrDefaultAsync();

            if (user == null) throw new ArgumentException(nameof(MessageConstant.ACCOUNT_INVALID));

            var checkPassword = PasswordHelper.VerifyHashPassword(user.PasswordHash, password);

            if (!checkPassword) throw new ArgumentException(nameof(MessageConstant.ACCOUNT_INVALID));

            var result = CreateTokenResponse(user);

            return result;
        }

        /// <summary>
        /// Create token for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public LoginResponse CreateTokenResponse(User user)
        {
            var result = new LoginResponse
            {
                Token = tokenService.CreateTokenBearer(user.Id)
            };

            return result;
        }
    }
}
