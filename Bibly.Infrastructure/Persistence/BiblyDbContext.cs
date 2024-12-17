namespace Bibly.Infrastructure.Persistence;
public class BiblyDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public BiblyDbContext(DbContextOptions<BiblyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
