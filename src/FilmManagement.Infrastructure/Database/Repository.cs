using FilmManagement.Core.Entities.Base;
using FilmManagement.Core.SharedKernel.Interfaces;
using FilmManagement.Infrastructure.Database.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Database
{
    public class Repository : IRepository
    {
        private readonly AppDbContext dbContext;
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected string CurrentUserId => GetLoggedInUserId();
        public Repository(IDbContextFactory dbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            dbContextFactory.SetHttpContextAccessor(httpContextAccessor);
            this.dbContext = dbContextFactory.CreateDbContext();
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            await dbContext.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> CheckExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return await dbContext.Set<T>().AnyAsync(predicate);
        }

        public IQueryable<T> Query<T>(
            Expression<Func<T, bool>> predicate = null
            , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , bool noTracking = false
        ) where T : BaseEntity
        {
            var query = dbContext
                .Set<T>()
                .AsQueryable();
            if (predicate != null) query = query.Where(predicate);
            if (noTracking) query = query.AsNoTracking();
            return orderBy == null ? query : orderBy(query);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            foreach (var entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result;
        }

        DatabaseFacade IRepository.Database => dbContext.Database;

        private string GetLoggedInUserId()
        {
            var loggedInUserId = httpContextAccessor.HttpContext == null
            ? string.Empty
            : httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return loggedInUserId;
        }
    }
}
