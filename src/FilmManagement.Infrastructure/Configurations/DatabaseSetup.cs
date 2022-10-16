using FilmManagement.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace FilmManagement.Infrastructure.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddAppDatabase(this IServiceCollection services) =>
            services.AddDbContext<AppDbContext>();
    }
}
