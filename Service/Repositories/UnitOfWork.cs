using Data;
using Service.Interfaces;

namespace Service.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IUrlRepository Url { get; private set; }

    public UnitOfWork(DataContext context)
    {
        _context = context;
        Url = new UrlRepository(context); 
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
