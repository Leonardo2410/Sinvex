using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sinvex.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Find(int id); 

        IEnumerable<T> FindAll(
            Expression<Func<T, bool>> Filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string IncludeProperties = null);

        T FirstOrDefault(Expression<Func<T, bool>> Filter = null,
             string IncludeProperties = null);

        void Add(T entity); 
        void Delete(int id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);

    }
}
