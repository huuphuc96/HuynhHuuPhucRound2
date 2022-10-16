using AutoMapper;
using FilmManagement.Core.Constants;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Interfaces;
using FilmManagement.Core.Models.Base;
using FilmManagement.Core.Models.Movie;
using FilmManagement.Core.Models.Movie.Request;
using FilmManagement.Core.SharedKernel.Interfaces;
using FilmManagement.Infrastructure.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        public MovieService(IRepository repository
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
        ) : base(repository, mapper, httpContextAccessor)
        {
        }
        /// <summary>
        /// Get list movies not use filter and paging
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovieModel>> GetListMovies()
        {
            List<MovieModel> lstData = new List<MovieModel>();
            MovieModel itemMovie = new MovieModel();
            var movies = await repository
                    .Query<Movie>(u => !u.IsDeleted)
                    .Include(a => a.InteractMovies)
                    .AsNoTracking()
                    .ToListAsync();

            foreach (var item in movies)
            {
                itemMovie.Code = item.Code;
                itemMovie.Id = item.Id;
                itemMovie.DisLikeCount = item.InteractMovies.Count(x => x.IsLike == false);
                itemMovie.LikeCount = item.InteractMovies.Count(x => x.IsLike == true);
                itemMovie.Image = item.Image;
                itemMovie.Title = item.Title;
                lstData.Add(itemMovie);
                itemMovie = new MovieModel();
            }
            return lstData;
        }

        /// <summary>
        /// Get list movies using paging with Task
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<PagedResult<MovieModel>> GetListMoviesPaging(FilterMovieRequest filter)
        {
            PagedResult<MovieModel> paginationSet = new PagedResult<MovieModel>();
            List<MovieModel> lstData = new List<MovieModel>();
            MovieModel itemMovie = new MovieModel();
            var movies = repository
                    .Query<Movie>(u => u.IsDeleted != true).Include(a => a.InteractMovies).AsNoTracking();
            int totalRow = movies.Count();
            movies = movies.Skip((filter.PageIndex - 1) * filter.PageSize).Take(filter.PageSize);
            foreach (var item in movies)
            {
                itemMovie.Code = item.Code;
                itemMovie.Id = item.Id;
                itemMovie.DisLikeCount = item.InteractMovies.Count(x => x.IsLike == false);
                itemMovie.LikeCount = item.InteractMovies.Count(x => x.IsLike == true);
                itemMovie.Image = item.Image;
                itemMovie.Title = item.Title;
                lstData.Add(itemMovie);
                itemMovie = new MovieModel();
            }
            if (lstData != null && lstData.Count > 0)
            {
                paginationSet = new PagedResult<MovieModel>()
                {
                    Results = lstData,
                    CurrentPage = filter.PageIndex,
                    RowCount = totalRow,
                    PageSize = filter.PageSize
                };
            }

            return paginationSet;
        }

        /// <summary>
        /// Update like/dislike service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateInteractAsync(InteractMovieRequest request)
        {
            using (var transaction = repository.Database.BeginTransaction())
            {
                try
                {
                    MovieModel movieModel = new MovieModel();
                    // 1. info movie
                    var movie = await repository
                    .Query<Movie>(u => u.Id == request.MovieId && u.IsDeleted != true).Include(a => a.InteractMovies)
                    .FirstOrDefaultAsync();

                    if (movie.IsDeleted)
                    {
                        throw new ArgumentException(nameof(MessageConstant.MOVIE_DELETED));
                    }

                    // 2. info interact movie
                    var interactMovie = movie.InteractMovies.ToList();

                    var interactMovieUserCurrent = interactMovie.FirstOrDefault(x => x.UserId == (request.UserId == null ? CurrentUserId : request.UserId));

                    if (interactMovieUserCurrent != null 
                        && interactMovieUserCurrent.IsLike.HasValue 
                        && interactMovieUserCurrent.IsLike == request.IsLike
                        && interactMovieUserCurrent.UserId == (request.UserId == null ? CurrentUserId : request.UserId))
                    {
                        return 0;
                    }
                    else
                    {
                        var interactMovieUpdate = repository
                            .Query<InteractMovie>(u => u.MovieId == request.MovieId && u.UserId == (request.UserId == null ? CurrentUserId : request.UserId))
                            .FirstOrDefault();

                        // create new InteractMovie
                        if (interactMovieUpdate == null)
                        {
                            var model = mapper.Map<InteractMovie>(request);
                            model.UserId = (request.UserId == null ? CurrentUserId : request.UserId);
                            await repository.AddAsync(model);
                            await repository.SaveChangesAsync();
                            transaction.Commit();
                            return 1;
                        }
                        // update InteractMovie
                        else
                        {
                            var interactMovieWithMovieId = repository.Query<InteractMovie>(x => x.MovieId == request.MovieId).FirstOrDefault();
                            var updateInteractMovie = mapper.Map(request, interactMovieWithMovieId);
                            repository.Update(updateInteractMovie);
                            transaction.Commit();
                            var result = await repository.SaveChangesAsync();

                            if (result <= 0) throw new ArgumentException(nameof(MessageConstant.UPDATE_FAIL));
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        /// <summary>
        /// Init data movie
        /// </summary>
        /// <returns></returns>
        public async Task InitMovieAsync()
        {
            try
            {
                List<Movie> lstData = new List<Movie>();
                var movie1 = new Movie
                {
                    Title = "ANTHROPOID",
                    Code = "ANTHROPOID",
                    Image = "img1.jfif",
                };
                lstData.Add(movie1);
                var movie2 = new Movie
                {
                    Title = "FLYING",
                    Code = "FLYING",
                    Image = "img2.jfif",
                };
                lstData.Add(movie2);
                var movie3 = new Movie
                {
                    Title = "DUPLICITY",
                    Code = "DUPLICITY",
                    Image = "img3.jfif",
                };
                lstData.Add(movie3);
                var movie4 = new Movie
                {
                    Title = "NORMAN LEAR",
                    Code = "NORMANLEAR",
                    Image = "img4.jfif",
                };
                lstData.Add(movie4);
                var movie5 = new Movie
                {
                    Title = "SUPER SONIC",
                    Code = "SUPERSONIC",
                    Image = "img5.jfif",
                };
                lstData.Add(movie5);
                var movie6 = new Movie
                {
                    Title = "ORANGE SUNSHINE",
                    Code = "ORANGESUNSHINE",
                    Image = "img6.jfif",
                };
                lstData.Add(movie6);
                var movie7 = new Movie
                {
                    Title = "SAUSAGE PARTY",
                    Code = "SAUSAGEPARTY",
                    Image = "img7.jfif",
                };
                lstData.Add(movie7);
                var movie8 = new Movie
                {
                    Title = "TALES OF HALLOWEEN",
                    Code = "TALESOFHALLOWEEN",
                    Image = "img8.jfif",
                };
                lstData.Add(movie8);
                var movie9 = new Movie
                {
                    Title = "THE AMERICAN PRESIDENT",
                    Code = "THEAMERICANPRESIDENT",
                    Image = "img9.jfif",
                };
                lstData.Add(movie9);
                var movie10 = new Movie
                {
                    Title = "THE CRAFT",
                    Code = "THECRAFT",
                    Image = "img10.jfif",
                };
                lstData.Add(movie10);
                var movie11 = new Movie
                {
                    Title = "THE HAUNTED MANSION",
                    Code = "THEHAUNTEDMANSION",
                    Image = "img11.jfif",
                };
                lstData.Add(movie11);
                var movie12 = new Movie
                {
                    Title = "THE MONEY PIT",
                    Code = "THEMONEYPIT",
                    Image = "img12.jfif",
                };
                lstData.Add(movie12);
                var movie13 = new Movie
                {
                    Title = "BRUCE WILLIS THE SIXTH SENSE",
                    Code = "BRUCEWILLISTHESIXTHSENSE",
                    Image = "img13.jfif",
                };
                lstData.Add(movie13);
                var movie14 = new Movie
                {
                    Title = "INSIDIOUS",
                    Code = "INSIDIOUS",
                    Image = "img14.jfif",
                };
                lstData.Add(movie14);
                var movie15 = new Movie
                {
                    Title = "WILDCATS NEVER DIE",
                    Code = "WILDCATSNEVERDIE",
                    Image = "img15.jfif",
                };
                lstData.Add(movie15);
                foreach (var item in lstData)
                {
                    var check = await CheckExistsAsync(x => x.Code == item.Code);
                    if (!check)
                    {
                        await repository.AddAsync(item);
                        await repository.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
            }
        }
    }
}
