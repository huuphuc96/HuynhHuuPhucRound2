using Ardalis.EFCore.Extensions;
using FilmManagement.Core.Entities;
using FilmManagement.Core.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public AppDbContext(
            DbContextOptions<AppDbContext> options
            , IHttpContextAccessor httpContextAccessor = null
        ) : base(options)
        {
            if (httpContextAccessor != null)
            {
                this.httpContextAccessor = httpContextAccessor;
            }
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<InteractMovie> InteractMovies { get; set; }

        /// <summary>
        /// Use it when run project WebUI
        /// That config use SqlServer
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=DESKTOP-9GJDCF0\\SQLEXPRESS;Database=BigStar;Password=123456;User ID=sa;Trusted_Connection = True; MultipleActiveResultSets = true";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<InteractMovie>()
                .HasOne<Movie>(e => e.Movie)
                .WithMany(d => d.InteractMovies)
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            // Using for execute stored procedure and return data
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var loggedInUserId = LoggedInUserId;
            AddOrUpdateCommonFields(loggedInUserId);
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return result;
        }

        protected string LoggedInUserId => httpContextAccessor?.HttpContext == null
            ? string.Empty
            : httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        private void AddOrUpdateCommonFields(string loggedInUserId)
        {
            var utcNow = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = utcNow;
                        entry.Entity.UpdatedAt = utcNow;
                        entry.Entity.CreatedBy = loggedInUserId;
                        entry.Entity.UpdatedBy = loggedInUserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = loggedInUserId;
                        entry.Entity.UpdatedAt = utcNow;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
