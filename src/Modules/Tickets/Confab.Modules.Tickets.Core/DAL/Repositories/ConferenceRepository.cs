using Confab.Modules.Tickets.Core.Entities;
using Confab.Modules.Tickets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Tickets.Core.DAL.Repositories;

internal class ConferenceRepository(TicketsDbContext ticketsDbContext) : IConferenceRepository
{
    private readonly DbSet<Conference> conferences = ticketsDbContext.Conferences;
    public Task<Conference> GetAsync(Guid id) => conferences.SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Conference conference)
    {
        await conferences.AddAsync(conference);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Conference conference)
    {
        conferences.Update(conference);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Conference conference)
    {
        conferences.Remove(conference);
        await ticketsDbContext.SaveChangesAsync();
    }
}