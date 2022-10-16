using AutoMapper;
using FilmManagement.Core.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace FilmManagement.Infrastructure.Configurations
{
    public static class AutoMapperSetup
    {
        [System.Obsolete]
        public static void AddAppAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(IMappingProfile));
            });
            services.AddAutoMapper();
        }
    }
}
