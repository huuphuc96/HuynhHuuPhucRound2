using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Models.User.Request
{
    public class UpdateProfileRequest
    {
        [Required(ErrorMessage = "First name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
