using FilmManagement.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Models.User.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = nameof(MessageConstant.USERNAME_REQUIRED))]
        public string Username { get; set; }

        [Required(ErrorMessage = nameof(MessageConstant.PASSWORD_REQUIRED))]
        [RegularExpression(RegexConstant.PASSWORD, ErrorMessage = nameof(MessageConstant.PASSWORD_INVALID_FORMAT))]
        public string Password { get; set; }
    }
}
