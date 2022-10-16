using FilmManagement.Core.Constants;
using FilmManagement.Core.Models.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Configurations
{
    public static class CorsSetup
    {
        private const string CORS_KEY = "CorsPolicy";

        public static void AddAppCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsOptions = new CorsSetting();
            configuration.GetSection("CorsSetting").Bind(corsOptions);
            if (corsOptions == null)
                throw new Exception(MessageConstant.SETTING_CORS_NOT_FOUND);

            var origins = corsOptions.AllowedHosts.Split(MessageConstant.ALLOWED_HOST_SEPARATED_CHARACTER);
            services.AddCors(options =>
            {
                options.AddPolicy(CORS_KEY,
                    builder => builder
                    .WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(CORS_KEY);
        }
    }
}
