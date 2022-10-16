using FilmManagement.Core.Entities;
using FilmManagement.Core.Models.Base;
using FilmManagement.Core.Models.Movie;
using FilmManagement.Core.Models.Movie.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmManagement.Core.Interfaces
{
    public interface IMovieService : IService<Movie>
    {
        Task<List<MovieModel>> GetListMovies();
        Task<int> UpdateInteractAsync(InteractMovieRequest request);
        Task InitMovieAsync();
        Task<PagedResult<MovieModel>> GetListMoviesPaging(FilterMovieRequest filter);
    }
}
