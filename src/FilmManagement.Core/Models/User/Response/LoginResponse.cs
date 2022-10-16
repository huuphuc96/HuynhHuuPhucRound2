using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagement.Core.Models.User.Response
{
    public class LoginResponse
    {
        public bool? IsCompletedRegistration { get; set; }
        public TokenResponse Token { get; set; }
        public UserLoginProfileModel Profile { get; set; }

    }
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
    public class UserLoginProfileModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
