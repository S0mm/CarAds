using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarAds.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            int? page = null,
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int? page = null,
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions);

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}