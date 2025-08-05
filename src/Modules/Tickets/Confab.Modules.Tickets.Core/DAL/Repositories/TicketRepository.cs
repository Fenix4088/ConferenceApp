using Confab.Modules.Tickets.Core.Entities;
using Confab.Modules.Tickets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Tickets.Core.DAL.Repositories;

internal class TicketRepository(TicketsDbContext ticketsDbContext) : ITicketRepository
{
    private readonly DbSet<Ticket> tickets = ticketsDbContext.Tickets;

    public Task<Ticket> GetAsync(Guid conferenceId, Guid userId)
        => tickets.SingleOrDefaultAsync(x => x.ConferenceId == conferenceId && x.UserId == userId);

    public Task<int> CountForConferenceAsync(Guid conferenceId)
        => tickets.CountAsync(x => x.ConferenceId == conferenceId);

    public async Task<IReadOnlyList<Ticket>> GetForUserAsync(Guid userId)
        => await tickets.Include(x => x.Conference).Where(x => x.UserId == userId).ToListAsync();

    public Task<Ticket> GetAsync(string code)
        => tickets.SingleOrDefaultAsync(x => x.Code == code);

    public async Task AddAsync(Ticket ticket)
    {
        await tickets.AddAsync(ticket);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task AddManyAsync(IEnumerable<Ticket> ticket)
    {
        await tickets.AddRangeAsync(ticket);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        tickets.Update(ticket);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ticket ticket)
    {
        tickets.Remove(ticket);
        await ticketsDbContext.SaveChangesAsync();
    }
}