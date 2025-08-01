using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Core.DAL.Repositories;

internal class HostRepository(ConferencesDbContext conferencesDbContext) : IHostRepository
{
    private readonly DbSet<Host> hosts = conferencesDbContext.Hosts;
    public Task<Host?> GetAsync(Guid id) => 
        hosts
            .Include(x => x.Conferences)
            .SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Host>> GetAllAsync() => await hosts.ToListAsync();

    public async Task AddAsync(Host host)
    {
        await hosts.AddAsync(host);
        await conferencesDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Host host)
    {
        hosts.Update(host);
        await conferencesDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Host host)
    {
        hosts.Remove(host);
        await conferencesDbContext.SaveChangesAsync();
    }
}