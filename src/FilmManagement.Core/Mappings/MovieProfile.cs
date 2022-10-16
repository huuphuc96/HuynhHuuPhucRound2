using AutoMapper;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Models.Movie;
using FilmManagement.Core.Models.Movie.Request;

namespace FilmManagement.Core.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieModel, Movie>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Movie, MovieModel>();
            //CreateMap<InteractMovieRequest, InteractMovie>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<InteractMovieRequest, InteractMovie>().ForMember(dest => dest.IsLike, opts => opts.MapFrom(src => src.IsLike));

            //CreateMap<InteractMovie, InteractMovieRequest>();
            ////CreateMap<User, ProfileModel>();
            //CreateMap<UserUpdateModelRequest, User>();
        }
    }
}
