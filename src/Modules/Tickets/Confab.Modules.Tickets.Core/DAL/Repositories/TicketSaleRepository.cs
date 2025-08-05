using Confab.Modules.Tickets.Core.Entities;
using Confab.Modules.Tickets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Tickets.Core.DAL.Repositories;

internal class TicketSaleRepository(TicketsDbContext ticketsDbContext) : ITicketSaleRepository
{
    private readonly DbSet<TicketSale> ticketSales = ticketsDbContext.TicketSales;
    
    public Task<TicketSale> GetAsync(Guid id)
        => ticketSales
            .Include(x => x.Tickets)
            .FirstOrDefaultAsync(x => x.Id == id);

    public Task<TicketSale> GetCurrentForConferenceAsync(Guid conferenceId, DateTime now)
        => ticketSales
            .Where(x => x.ConferenceId == conferenceId)
            .OrderBy(x => x.From)
            .Include(x => x.Tickets)
            .LastOrDefaultAsync(x => x.From <= now && x.To >= now);

    public async Task<IReadOnlyList<TicketSale>> GetAllForConferenceAsync(Guid conferenceId)
        => await ticketSales
            .AsNoTracking()
            .Where(x => x.ConferenceId == conferenceId)
            .Include(x => x.Tickets)
            .ToListAsync();

    public async Task AddAsync(TicketSale ticketSale)
    {
        await ticketSales.AddAsync(ticketSale);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketSale ticketSale)
    {
        ticketSales.Update(ticketSale);
        await ticketsDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TicketSale ticketSale)
    {
        ticketSales.Remove(ticketSale);
        await ticketsDbContext.SaveChangesAsync();
    }
}