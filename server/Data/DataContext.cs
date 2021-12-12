using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Url> Urls => Set<Url>();
}