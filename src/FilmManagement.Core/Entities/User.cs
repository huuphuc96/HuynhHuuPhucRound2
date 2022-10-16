using FilmManagement.Core.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Entities
{
    public class User : GuidEntity
    {
        [StringLength(200)]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
    }
}
