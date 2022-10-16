using FilmManagement.Infrastructure.Database.EntityConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;

namespace FilmManagement.Infrastructure.Database.Factory
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>, IDbContextFactory
    {
        private readonly string _connnection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IHttpContextAccessor _publicHttpContextAccessor { get; set; }
        public DbContextFactory() { }

        public DbContextFactory(string connnection, IHttpContextAccessor httpContextAccessor = null)
        {
            _connnection = connnection;
            _httpContextAccessor = httpContextAccessor;
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            if (_httpContextAccessor == null)
            {
                return new AppDbContext(DbContextConfiguration.CreateOption(_connnection),_publicHttpContextAccessor);
            }
            return new AppDbContext(DbContextConfiguration.CreateOption(_connnection),_httpContextAccessor);
        }

        public void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _publicHttpContextAccessor = httpContextAccessor;
        }
    }
}
