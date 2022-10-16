namespace FilmManagement.Core.Models.Movie
{
    public class MovieModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int? DisLikeCount { get; set; }
        public int? LikeCount { get; set; }
    }
}
