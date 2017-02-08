using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public class SZRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public SZRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            else
            {
                DbContext = dbContext;
                DbSet = DbContext.Set<T>();
            }
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T newEntity)
        {
            DbSet.Add(newEntity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

    }
}
