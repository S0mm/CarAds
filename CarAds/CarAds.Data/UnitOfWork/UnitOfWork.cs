using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAds.Data.Contracts;
using CarAds.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarAds.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }
            
            var type = typeof(TEntity);
            
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }
            
            return (IRepository<TEntity>) _repositories[type];
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}