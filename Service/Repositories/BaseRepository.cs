using System.Linq.Expressions;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DataContext _context;
    internal DbSet<T> _set;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _set.Where(predicate).SingleOrDefault();
    }
}
