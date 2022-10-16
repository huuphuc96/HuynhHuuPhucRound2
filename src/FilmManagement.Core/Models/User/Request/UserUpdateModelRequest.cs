using FilmManagement.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Models.User.Request
{
    public class UserCreateModelRequest
    {
        [RegularExpression("^([\\w.-](?!\\.(com|net|html?|js|jpe?g|png)$)){3,}$", ErrorMessage = nameof(MessageConstant.USERNAME_INVALID_FORMAT))]
        [Required(ErrorMessage = nameof(MessageConstant.USERNAME_REQUIRED))]
        public string UserName { get; set; }

        [Required(ErrorMessage = nameof(MessageConstant.EMAIL_REQUIRED))]
        [EmailAddress(ErrorMessage = nameof(MessageConstant.EMAIL_INVALID_FORMAT))]
        public string Email { get; set; }

        [Required(ErrorMessage = nameof(MessageConstant.PASSWORD_REQUIRED))]
        public string Password { get; set; }
    }
}
