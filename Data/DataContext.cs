using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DataContext : DbContext
{
    public DbSet<Url> Urls => Set<Url>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Url>()
            .HasIndex(url => url.Name)
            .IsUnique(true);
    }
    
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}
