using FilmManagement.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmManagement.Core.SharedKernel.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> Query<T>(
            Expression<Func<T, bool>> predicate = null
            , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , bool noTracking = false
        ) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task<IEnumerable<T>> AddAsync<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Update<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task<bool> CheckExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<int> SaveChangesAsync();
        DatabaseFacade Database { get; }
    }
}
