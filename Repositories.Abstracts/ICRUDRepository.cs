using System;

namespace Repositories.Abstracts
{
    public interface ICrudRepository<TEntity>
    {
        public TEntity Add(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity GetById(Guid id);
        public TEntity Delete(TEntity entity);
        public void SaveChanges();
    }
}