using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.Models.User.Request;
using FilmManagement.WebUI.Models.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmManagement.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="loginService"></param>
        /// <param name="userService"></param>
        public LoginController(ILoginService loginService
            , IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        /// <summary>
        /// Get: Login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("Movie/Index");
            }
            return View();
        }

        /// <summary>
        /// Post: Login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Index")]
        public async Task<IActionResult> IndexAsync([FromBody] LoginViewModel loginViewModel) //perform validation for login authentication
        {
            if (ModelState.IsValid)
            {
                var username = loginViewModel.Username;
                var password = loginViewModel.Password;
                try
                {
                    var result = await _loginService.LoginAsync(username, password);
                    var userInfo = await _userService.FindByUserNameAsync(username);
                    if (result.Token.AccessToken != null)
                    {
                        // create claims
                        List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "Cookie Authen"),
                            new Claim(ClaimTypes.Email, username),
                            new Claim("Username", username),
                            new Claim("UserId", userInfo.Id)
                        };

                        // create identity
                        ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                        // create principal
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        // sign-in
                        await HttpContext.SignInAsync(
                            scheme: "BigStarSecurityScheme",
                            principal: principal,
                            properties: new AuthenticationProperties
                            {
                                IsPersistent = loginViewModel.RememberMe ?? false, // for 'remember me' feature
                            });
                        return Json(new { redirectToUrl = Url.Action("Index", "Movie") });
                    }
                    else
                    {
                    }
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return Json(ex.Message);
                }
            }

            return View(loginViewModel);
        }

        /// <summary>
        /// Get: Register
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View("Register");
        }

        /// <summary>
        /// Post: Register new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterViewModel model)
        {
            UserCreateModelRequest modelRequest = new UserCreateModelRequest();
            modelRequest.UserName = model.Username;
            modelRequest.Password = model.Password;
            modelRequest.Email = model.Email;
            try
            {

                var data = await _userService.AddUserAsync(modelRequest);
                return Json(data.IsSuccess);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                    scheme: "BigStarSecurityScheme");
            return Json(new { redirectToUrl = "Login/Index" });
        }
    }
}
