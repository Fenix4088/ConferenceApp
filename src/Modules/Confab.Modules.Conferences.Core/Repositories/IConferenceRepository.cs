using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories;

internal interface IConferenceRepository
{
    Task<Conference> GetAsync(Guid id);
    Task<IReadOnlyList<Conference>> GetAllAsync();
    Task AddAsync(Conference conference);
    Task UpdateAsync(Conference conference);
    Task DeleteAsync(Guid id);
}