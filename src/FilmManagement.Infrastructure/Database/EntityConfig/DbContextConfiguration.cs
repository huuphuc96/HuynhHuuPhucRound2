using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FilmManagement.Infrastructure.Database.EntityConfig
{
    public class DbContextConfiguration
    {
        public static DbContextOptions<AppDbContext> CreateOption(string connection = null)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            if (!string.IsNullOrEmpty(connection))
            {
                return builder.UseInMemoryDatabase(connection).ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            }
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("SqlConnection");

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                builder.UseSqlServer(connectionString);
            }
            return builder.Options;
        }
    }
}
