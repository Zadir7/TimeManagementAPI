using System;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Abstracts
{
    public abstract class DbSetRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        
        public DbSetRepository(DbSet<TEntity> dbSet, DbContext context)
        {
            DbSet = dbSet;
            _context = context;
        }
        
        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public TEntity Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
            return entity;
        }
    }
}