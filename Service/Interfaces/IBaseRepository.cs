using System.Linq.Expressions;

namespace Service.Interfaces;

public interface IBaseRepository<T> where T : class
{
    void Add(T entity);
    T? Get(Expression<Func<T, bool>> predicate);
}