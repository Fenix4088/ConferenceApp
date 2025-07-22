using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories;

internal interface IHostRepository
{
    Task<Host> GetAsync(Guid id);
    Task<IEnumerable<Host>> GetAllAsync();
    Task AddAsync(Host host);
    Task UpdateAsync(Host host);
    Task DeleteAsync(Guid id);
}