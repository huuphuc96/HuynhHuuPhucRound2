using FilmManagement.Core.Interfaces;
using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.SharedKernel.Interfaces;
using FilmManagement.Infrastructure.Database;
using FilmManagement.Infrastructure.Database.Factory;
using FilmManagement.Infrastructure.Queries;
using FilmManagement.Infrastructure.Services;
using FilmManagement.Infrastructure.Services.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FilmManagement.Infrastructure.Configurations
{
    public static class ServiceSetup
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
                // the code above will find the assembly that contains IService and scan for all of the classes it contains.
                scan.FromAssemblies(assemblies)
                // only include classes which can be assigned to (i.e. implement) a specific interface
                .AddClasses(classes => classes.AssignableTo(typeof(IService<>)))
                // don't worry about duplicate registrations, add new registrations for existing services.
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                // registering services which match a standard naming convention
                .AsMatchingInterface()
                // specifying the lifetime of the registered classes
                .WithScopedLifetime();
            });
            services.Scan(scan =>
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
                // the code above will find the assembly that contains IService and scan for all of the classes it contains.
                scan.FromAssemblies(assemblies)
                // only include classes which can be assigned to (i.e. implement) a specific interface
                .AddClasses(classes => classes.AssignableTo(typeof(IBaseQueries)))
                // don't worry about duplicate registrations, add new registrations for existing services.
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                // registering services which match a standard naming convention
                .AsMatchingInterface()
                // specifying the lifetime of the registered classes
                .WithScopedLifetime();
            });

            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IRepository), typeof(Repository));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
