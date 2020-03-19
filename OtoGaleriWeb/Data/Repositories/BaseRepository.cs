using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity.Migrations;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private GaleriDBEntities _dbContext;

        public BaseRepository(GaleriDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public TEntity List(int entityId)
        {
            return _dbContext.Set<TEntity>().Find(entityId);
        }

        public List<TEntity> ListAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().AddOrUpdate(entity);
        }
    }
}
