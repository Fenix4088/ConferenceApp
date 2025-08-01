using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Repositories;

internal interface ISpeakersRepository
{
    Task<Speaker> GetAsync(Guid id);
    Task<IReadOnlyList<Speaker>> GetAllAsync();
    Task AddAsync(Speaker speaker);
    Task UpdateAsync(Speaker speaker);
    Task DeleteAsync(Speaker speaker);
    Task<bool> ExistsAsync(Guid id);
}