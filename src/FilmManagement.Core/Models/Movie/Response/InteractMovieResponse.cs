namespace FilmManagement.Core.Models.Movie.Response
{
    class InteractMovieResponse
    {
        public string IdMovie { get; set; }
        public int? LikeMovieCount { get; set; }
        public int? DisLikeMovieCount { get; set; }
    }
}
