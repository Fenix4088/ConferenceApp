using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Core.DAL.Repositories;

internal class SpeakersRepository(SpeakersDbContext speakersDbContext) : ISpeakersRepository
{
    private readonly DbSet<Speaker> speakers = speakersDbContext.Speakers;
    
    public Task<Speaker?> GetAsync(Guid id) => speakers
        .SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<Speaker>> GetAllAsync() => await speakers
        .ToListAsync();

    public async Task AddAsync(Speaker speaker)
    {
        await speakers.AddAsync(speaker);
        await speakersDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Speaker speaker)
    {
        speakers.Update(speaker);
        await speakersDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Speaker speaker)
    {
        speakers.Remove(speaker);
        await speakersDbContext.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return speakers.AnyAsync(x => x.Id == id);
    }
}