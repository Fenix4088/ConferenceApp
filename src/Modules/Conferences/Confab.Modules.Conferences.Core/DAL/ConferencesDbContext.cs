using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Core.DAL;

internal class ConferencesDbContext : DbContext
{
    public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options) : base(options)
    {
        //! Enable legacy timestamp behavior for PostgreSQL
        // https://stackoverflow.com/questions/69961449/net6-and-datetime-problem-cannot-write-datetime-with-kind-utc-to-postgresql-ty
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Conference> Conferences { get; set; }
    public DbSet<Host> Hosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("conferences");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}