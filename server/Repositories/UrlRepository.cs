using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Interfaces;
using server.Payloads;

namespace server.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly DataContext _context;

    public UrlRepository(DataContext context)
    {
        _context = context;
    }

    public UrlPayload? GetUrlPayload(string slice)
    {
        return _context.Urls
            .Where(url => url.UrlSlice == slice)
            .Select(url => new UrlPayload(url.UrlName))
            .AsNoTracking()
            .FirstOrDefault();
    }

    public Url Add(Url url)
    {
        _context.Add(url);
        return url;
    }
}