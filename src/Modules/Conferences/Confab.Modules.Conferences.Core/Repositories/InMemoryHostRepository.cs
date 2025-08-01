using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories;

internal class InMemoryHostRepository : IHostRepository
{
    // ! Not thread-safe, use Concurrent collections or locks for production code.
    private readonly List<Host> _hosts = new();

    public Task<Host> GetAsync(Guid id) => Task.FromResult(_hosts.FirstOrDefault(h => h.Id == id));

    public Task<IEnumerable<Host>> GetAllAsync() => Task.FromResult<IEnumerable<Host>>(_hosts);

    public Task AddAsync(Host host)
    {
        _hosts.Add(host);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Host host)
    {
        var existingHost = _hosts.FirstOrDefault(h => h.Id == host.Id);
        if (existingHost != null)
        {
            _hosts.Remove(existingHost);
            _hosts.Add(host);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Host host)
    {

        _hosts.Remove(host);
        return Task.CompletedTask;
    }
}