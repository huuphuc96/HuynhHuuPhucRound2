using FilmManagement.Core.Interfaces;
using FilmManagement.Core.Interfaces.UserManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace FilmManagement.WebUI.Extensions
{
    /// <summary>
    /// Web Host Extensions
    /// </summary>
    public static class InitDataExtension
    {
        /// <summary>
        /// Seed Data
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                Task.Run(async () => await userService.InitAdminAccountAsync()).GetAwaiter().GetResult();
                var movieService = scope.ServiceProvider.GetRequiredService<IMovieService>();
                Task.Run(async () => await movieService.InitMovieAsync()).GetAwaiter().GetResult();
            }

            return host;
        }
    }
}
