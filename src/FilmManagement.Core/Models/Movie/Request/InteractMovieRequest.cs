
namespace FilmManagement.Core.Models.Movie.Request
{
    public class InteractMovieRequest
    {
        public bool? IsLike { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }
    }
}
