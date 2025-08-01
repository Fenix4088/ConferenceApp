using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Core.DAL.Repositories;

internal class ConferenceRepository(ConferencesDbContext conferencesDbContext) : IConferenceRepository
{
    private readonly DbSet<Conference> conferences = conferencesDbContext.Conferences;
    public Task<Conference> GetAsync(Guid id) => conferences.Include(x => x.Host).SingleOrDefaultAsync(x => x.Id == id);
    public async Task<IReadOnlyList<Conference>> GetAllAsync() => await conferences.ToListAsync();

    public async Task AddAsync(Conference conference)
    {
        await conferences.AddAsync(conference);
        await conferencesDbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Conference conference)
    {
        conferences.Update(conference);
        return conferencesDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Conference conference)
    {
        conferences.Remove(conference);
        await conferencesDbContext.SaveChangesAsync();
    }
}