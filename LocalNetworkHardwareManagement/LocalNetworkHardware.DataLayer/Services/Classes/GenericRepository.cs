using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T:class
    {
        protected LocalNetworkHardwareManagement_DBEntities _db;
        protected DbSet<T> _dbSet;
        public GenericRepository(LocalNetworkHardwareManagement_DBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(condition);
            return query.ToList();
        }

        public virtual T GetSingleByKey(object key)
        {
            return _dbSet.Find(key);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object key)
        {
            Delete(GetSingleByKey(key));
        }

    }
}
