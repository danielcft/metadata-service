using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MetadataService.Infrastructure
{
  public interface IRepository<T> where T : EntityBase
  {
    T GetById(int id, Expression<Func<T, object>> includePredicate = null);
    IEnumerable<T> List();
    IEnumerable<T> List(Expression<Func<T, bool>> predicate,
                    Expression<Func<T, object>> includePredicate = null);
    void Add(T entity);
    void Delete(T entity);
    void Edit(T entity);
  }

  public abstract class EntityBase
  {
  }
}
