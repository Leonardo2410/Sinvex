using Microsoft.EntityFrameworkCore;
using Sinvex.DataAccess.Data;
using Sinvex.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sinvex.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        private ApplicationDbContext context;


        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>(); 
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);      // Insert into Table
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);      // Selet * from
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if(Filter != null)
            {
                query = query.Where(Filter);
            }

            if(IncludeProperties != null)
            {
                foreach(var property in IncludeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if(OrderBy != null)
            {
                return OrderBy(query).ToList();    
            }

            return query.ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> Filter = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            if (IncludeProperties != null)
            {
                foreach (var property in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
