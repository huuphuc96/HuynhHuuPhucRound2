using AutoMapper;
using FilmManagement.Core.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FilmManagement.Infrastructure.Queries
{
    public interface IBaseQueries
    {

    }
    public class BaseQueries : IBaseQueries
    {
        protected readonly string _sqlConnection;
        protected readonly IMapper _mapper;
        protected readonly IRepository _repository;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected string CurrentUserId => GetLoggedInUserId();
        public BaseQueries(IRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            if (repository != null)
            {
                _sqlConnection = repository.Database.GetDbConnection()?.ConnectionString;
            }
            _mapper = mapper;
        }

        private string GetLoggedInUserId()
        {
            var loggedInUserId = _httpContextAccessor.HttpContext == null
            ? string.Empty
            : _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return loggedInUserId;
        }
    }
}
