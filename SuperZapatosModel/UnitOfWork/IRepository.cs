using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        T GetById(object id);

        void Insert(T newEntity);

        void Update(T entity);

        void Delete(T entity);
    }
}
