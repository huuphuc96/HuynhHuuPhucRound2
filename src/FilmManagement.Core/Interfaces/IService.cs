using FilmManagement.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Core.Interfaces
{

    public interface IService<TEntity>
        where TEntity : GuidEntity
    {
        Task<int> AddAsync<TModel>(TModel entry);
        Task<string> AddReturnIdAsync<TModel>(TModel entry);
        Task<int> AddAsync<TModel>(IEnumerable<TModel> entries);
        Task<TModel> GetOneAsync<TModel>(
            Expression<Func<TEntity, bool>> predicate = null
            , bool noTracking = false
        );
        Task<IEnumerable<TModel>> GetListAsync<TModel>(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , bool noTracking = false
        );
        Task<int> UpdateAsync<TModel>(string id, TModel entry);
    }
}
