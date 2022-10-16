using FilmManagement.API.Common;
using FilmManagement.Core.Constants;
using FilmManagement.Core.Helpers;
using FilmManagement.Core.Interfaces;
using FilmManagement.Core.Models.Movie.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmManagement.API.Controllers
{
    [ApiExplorerSettings(GroupName = SwaggerGroup.BIGSTAR)]
    [Route("Movie")]
    public class MovieController : BaseApiController
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        /// <summary>
        /// Get list movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllMovies()
        {
            var data = await _movieService.GetListMovies();
            return Ok(ResponseHelper.Success(data));
        }

        /// <summary>
        /// Get list movies using filter and paging
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPaging")]
        [Authorize]
        public async Task<IActionResult> GetAllMoviesPaging([FromQuery] FilterMovieRequest filter)
        {
            var data = await _movieService.GetListMoviesPaging(filter);
            return Ok(ResponseHelper.Success(data));
        }

        /// <summary>
        /// Interact movie (like or dislike)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InteractMovie")]
        [Authorize]
        public async Task<IActionResult> InteractMovie([FromBody] InteractMovieRequest model)
        {
            var data = await _movieService.UpdateInteractAsync(model);
            return Ok(ResponseHelper.Success(data));
        }
    }
}
