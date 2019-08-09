using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarAds.Data.Contracts;
using Microsoft.EntityFrameworkCore;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

namespace CarAds.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Get();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetAsync();
        }
        
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return Get(filter, null, null, null);
        }
        
        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await GetAsync(filter, null, null, null);
        }
        
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            int? page = null, // the page parameter will be ignored if there is not at least one SortExpression
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions)
        {
            var query = GetQuery(filter, page, pageSize, sortExpressions);
            return query.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int? page = null, // the page parameter will be ignored if there is not at least one SortExpression
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions)
        {
            var query = GetQuery(filter, page, pageSize, sortExpressions);
            return await query.ToListAsync();
        }
        
        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }
        
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)  
        {  
            DbSet.AddRange(entities);
        }  

        
        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        private IQueryable<TEntity> GetQuery(
            Expression<Func<TEntity, bool>> filter = null,
            int? page = null,
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            // https://datatellblog.wordpress.com/2015/02/26/server-side-paging-with-entity-framework/
            if (sortExpressions != null)
            {
                IOrderedQueryable<TEntity> orderedQuery = null;
                for (var i = 0; i < sortExpressions.Count(); i++)
                {
                    if (i == 0)
                    {
                        orderedQuery = 
                            sortExpressions[i].SortDirection == ListSortDirection.Ascending 
                                ? query.OrderBy(sortExpressions[i].SortBy) 
                                : query.OrderByDescending(sortExpressions[i].SortBy);
                    }
                    else
                    {
                        orderedQuery =
                            sortExpressions[i].SortDirection == ListSortDirection.Ascending 
                                ? orderedQuery.ThenBy(sortExpressions[i].SortBy) 
                                : orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                    }
                }
 
                if (page != null && pageSize != null)
                {
                    query = orderedQuery.Skip(((int)page - 1) * (int)pageSize);
                }
            }
 
            if (pageSize != null)
            {
                query = query.Take((int)pageSize);
            }
            
            return query;
        }
    }
}