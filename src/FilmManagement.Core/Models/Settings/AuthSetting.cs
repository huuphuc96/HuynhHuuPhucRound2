namespace FilmManagement.Core.Models.Settings
{
    public class AuthSetting
    {
        public string SecretKey { get; set; }
        public int AccessTokenExpiresInSecconds { get; set; }
    }
}
