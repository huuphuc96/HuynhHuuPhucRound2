using Microsoft.AspNetCore.Http;

namespace FilmManagement.Infrastructure.Database.Factory
{
    public interface IDbContextFactory
    {
        void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor);
        AppDbContext CreateDbContext(string[] args = null);
    }
}
