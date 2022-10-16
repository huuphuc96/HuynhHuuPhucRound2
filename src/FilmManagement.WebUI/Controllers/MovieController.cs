using FilmManagement.Core.Interfaces;
using FilmManagement.Core.Models.Movie.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmManagement.WebUI.Controllers
{
    [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IHttpContextAccessor _httpContextAccessor; 
        public string LoggedInUser => User.Identity.Name;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="movieService"></param>
        /// <param name="httpContextAccessor"></param>
        public MovieController(IMovieService movieService, IHttpContextAccessor httpContextAccessor)
        {
            this._movieService = movieService;
            this._httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get: Movie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var datas = await _movieService.GetListMovies();
            ViewBag.Data = datas;
            var req = (User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "Username").FirstOrDefault();
            string reqValue = req.Value;
            ViewBag.CurrentUsername = reqValue;
            return View(datas);
        }

        /// <summary>
        /// Interact movie (like or dislike)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> InteractMovie([FromBody] InteractMovieRequest model)
        {
            var req = (User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            string reqValue = req.Value;
            model.UserId = reqValue;
            var data = await _movieService.UpdateInteractAsync(model);
            return Json(new { code = data });
        }
    }
}
