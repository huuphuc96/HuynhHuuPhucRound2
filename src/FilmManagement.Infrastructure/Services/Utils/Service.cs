using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmManagement.Core.Interfaces;
using FilmManagement.Core.SharedKernel;
using FilmManagement.Core.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmManagement.Infrastructure.Services.Utils
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : GuidEntity
    {
        protected readonly IRepository repository;
        protected readonly IMapper mapper;
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected string CurrentUserId => GetLoggedInUserId();
        public Service(
            IRepository repository
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
        )
        {
            this.mapper = mapper;
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public virtual async Task<int> AddAsync<TModel>([NotNull] TModel entry)
        {
            var entity = mapper.Map<TEntity>(entry);
            await repository.AddAsync(entity);
            var result = await repository.SaveChangesAsync();
            return result;
        }

        public virtual async Task<string> AddReturnIdAsync<TModel>([NotNull] TModel entry)
        {
            var entity = mapper.Map<TEntity>(entry);
            await repository.AddAsync(entity);
            var result = await repository.SaveChangesAsync();
            if (result > 0)
            {
                return entity.Id;
            }
            return null;
        }

        public virtual async Task<int> AddAsync<TModel>([NotNull] IEnumerable<TModel> entries)
        {
            var result = 0;
            if (entries != null && entries.Any())
            {
                var entities = entries.Select(x => mapper.Map<TEntity>(x));
                await repository.AddAsync(entities);
                result = await repository.SaveChangesAsync();
            }
            return result;
        }

        public virtual async Task<bool> CheckExistsAsync(string id)
        {
            return await repository.Query<TEntity>().AnyAsync(x => x.Id == id);
        }

        public virtual async Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.CheckExistsAsync<TEntity>(predicate);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync<TModel>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var data = await repository
                .Query<TEntity>(orderBy: orderBy)
                .ProjectTo<TModel>()
                .ToListAsync();
            return data;
        }

        public virtual async Task<TModel> GetByIdAsync<TModel>(string id)
        {
            var result = await repository
                .Query<TEntity>(x => x.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TModel>> GetListAsync<TModel>(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , bool noTracking = false)
        {
            var query = repository.Query<TEntity>(predicate, orderBy, noTracking);
            return await query.ProjectTo<TModel>().ToListAsync();
        }

        public virtual async Task<TModel> GetOneAsync<TModel>(
            Expression<Func<TEntity, bool>> predicate = null
            , bool noTracking = false
        )
        {
            var query = repository.Query<TEntity>(predicate, null, noTracking);
            return await query.ProjectTo<TModel>().FirstOrDefaultAsync();
        }

        public virtual async Task<int> UpdateAsync<TModel>(
            [NotNull] string id
            , [NotNull] TModel entry
        )
        {
            if (string.IsNullOrEmpty(id) || entry == null) return 0;
            var currentEntity = await repository
                .Query<TEntity>(predicate: x => x.Id == id)
                .FirstOrDefaultAsync();
            if (currentEntity == null) return 0;

            var entityUpdate = mapper.Map(entry, currentEntity);
            entityUpdate.Id = id;
            repository.Update(entityUpdate);
            var result = await repository.SaveChangesAsync();
            return result;
        }

        private string GetLoggedInUserId()
        {
            var loggedInUserId = httpContextAccessor.HttpContext == null
            ? string.Empty
            : httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return loggedInUserId;
        }
    }
}
