using AutoMapper;
using FilmManagement.API.Common;
using FilmManagement.Core.Constants;
using FilmManagement.Core.Helpers;
using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.Models.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmManagement.API.Controllers
{
    [ApiExplorerSettings(GroupName = SwaggerGroup.BIGSTAR)]
    [Route("Account")]
    public class LoginController : BaseApiController
    {
        private readonly ILoginService loginService;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loginService"></param>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        public LoginController(
            ILoginService loginService
            , IUserService userService
            , IMapper mapper
        )
        {
            this.loginService = loginService;
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Post Login
        /// </summary>
        /// <param name="model">Login model</param>
        /// <returns>Login response model</returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginRequest model)
        {
            var data = await loginService.LoginAsync(model.Username, model.Password);
            return Ok(ResponseHelper.Success(data));
        }

        /// <summary>
        /// Register account
        /// </summary>
        /// <param name="model">UserCreate model</param>
        /// <returns>Register account response model</returns>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] UserCreateModelRequest model)
        {
            var data = await userService.AddUserAsync(model);
            return Ok(ResponseHelper.Success(data));
        }
    }
}