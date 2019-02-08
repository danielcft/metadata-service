using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MetadataService.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly MetadataContext _context;

        public Repository(MetadataContext context)
        {
            _context = context;
        }
        public T GetById(int id, Expression<Func<T, object>> includePredicate = null)
        {
            var set = _context.Set<T>();
            if (includePredicate != null)
            {
                set.Include(includePredicate);
            }
            return set.Find(id);
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate,
          Expression<Func<T, object>> include
          )
        {
            if (include != null)
            {
                return _context.Set<T>().Include(include).Where(predicate).AsEnumerable();
            }
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
