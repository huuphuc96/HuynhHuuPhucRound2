using AutoMapper;
using FilmManagement.Core.Constants;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Helpers;
using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.Models.User.Request;
using FilmManagement.Core.Models.User.Response;
using FilmManagement.Core.SharedKernel.Interfaces;
using FilmManagement.Infrastructure.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Services.UserManagement
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(
            IRepository repository
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
        ) : base(repository, mapper, httpContextAccessor)
        {
        }

        /// <summary>
        /// Find one User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> FindByIdAsync(string id)
        {
            var user = await repository
                    .Query<User>(u => u.Id == id)
                    .FirstOrDefaultAsync();

            return user;
        }
        /// <summary>
        /// Find one User by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User> FindByUserNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;
            return await repository.Query<User>(x => x.Username == username.Trim().ToLower() && !x.IsDeleted).FirstOrDefaultAsync();
        }
        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserModel> AddUserAsync(UserCreateModelRequest request)
        {
            using (var transaction = repository.Database.BeginTransaction())
            {
                try
                {
                    var regexEmail = RegexConstant.EMAIL;
                    var matchEmail = Regex.Match(request.Email, regexEmail, RegexOptions.IgnoreCase);

                    if (!matchEmail.Success)
                    {
                        throw new ArgumentException(nameof(MessageConstant.EMAIL_INVALID_FORMAT));
                    }
                    var regexPassword = RegexConstant.PASSWORD;
                    var matchPassword = Regex.Match(request.Password, regexPassword, RegexOptions.IgnoreCase);

                    if (!matchPassword.Success)
                    {
                        throw new ArgumentException(nameof(MessageConstant.PASSWORD_INVALID_FORMAT));
                    }
                    var user = await FindByUserNameAsync(request.UserName);
                    if (user != null)
                    {
                        throw new ArgumentException(nameof(MessageConstant.USER_ALREADY_EXISTS));
                    }

                    user = await FindByEmailAsync(request.Email);
                    if (user != null)
                    {
                        throw new ArgumentException(nameof(MessageConstant.EMAIL_ALREADY_EXISTS));
                    }

                    user = mapper.Map<User>(request);
                    user.Email = request.Email.Trim().ToLower();
                    request.UserName = request.UserName.Trim();
                    request.Password = request.Password.Trim();
                    user.Username = request.UserName.Trim().ToLower();
                    user.PasswordHash = PasswordHelper.HashPassword(request.Password);
                    await repository.AddAsync(user);
                    await repository.SaveChangesAsync();
                    transaction.Commit();

                    // return info user has created
                    UserModel rs = new UserModel();
                    rs.Email = user.Email;
                    rs.Username = user.Username;
                    rs.IsSuccess = true;

                    return rs;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw new ArgumentException(ex.Message);
                }
            }
        }
        /// <summary>
        /// init data
        /// </summary>
        /// <returns></returns>
        public async Task InitAdminAccountAsync()
        {
            try
            {
                var check = await CheckExistsAsync(x => x.Username == InitConstant.ADMIN_USERNAME);
                if (!check)
                {
                    var admin = new User
                    {
                        Username = InitConstant.ADMIN_USERNAME,
                        PasswordHash = PasswordHelper.HashPassword(InitConstant.ADMIN_PASSWORD),
                        Email = InitConstant.ADMIN_EMAIL
                    };

                    await repository.AddAsync(admin);
                    await repository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
            }
        }
        /// <summary>
        /// Find one User by email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) return null;
            var user = await repository
                .Query<User>(u => u.Email == email.Trim().ToLower() && !u.IsDeleted)
                .FirstOrDefaultAsync();
            return user;
        }
    }
}
