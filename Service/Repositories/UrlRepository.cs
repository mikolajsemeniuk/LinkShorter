using Data;
using Data.Entities;
using Service.Interfaces;

namespace Service.Repositories;

public class UrlRepository : BaseRepository<Url>, IUrlRepository
{
    private readonly DataContext _context;
    public UrlRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}