using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CarAds.Data.Repositories
{
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class Repository<TEntity> where TEntity : class
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Get();
        }
        
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            // Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? page = null, // the page parameter will be ignored if there is not at least one SortExpression
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions)
        {
            IQueryable<TEntity> query = dbSet;

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
            
//            return orderBy != null 
//                ? orderBy(query).ToList() 
//                : query.ToList();

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)  
        {  
            dbSet.AddRange(entities);
        }  

        
        public virtual void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}