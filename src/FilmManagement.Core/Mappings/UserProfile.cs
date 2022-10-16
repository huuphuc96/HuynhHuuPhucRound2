using AutoMapper;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Models.User.Request;
using FilmManagement.Core.Models.User.Response;

namespace FilmManagement.Core.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, User>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<User, UserLoginProfileModel>();
            CreateMap<UserCreateModelRequest, User>().ForMember(x => x.PasswordHash, opt => opt.Ignore());
        }
    }
}
