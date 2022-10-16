using FilmManagement.Core.Models.Base;

namespace FilmManagement.Core.Models.User.Response
{
    public class UserModel : BaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsSuccess { get; set; }
    }
}
