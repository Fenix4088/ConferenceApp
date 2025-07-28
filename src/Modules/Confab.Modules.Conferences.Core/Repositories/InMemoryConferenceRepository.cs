using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories;

internal class InMemoryConferenceRepository : IConferenceRepository
{
    private readonly List<Conference> _conferences = new();

    public Task<Conference> GetAsync(Guid id) => Task.FromResult(_conferences.FirstOrDefault(c => c.Id == id));

    public Task<IReadOnlyList<Conference>> GetAllAsync() => Task.FromResult<IReadOnlyList<Conference>>(_conferences);

    public Task AddAsync(Conference conference)
    {
        _conferences.Add(conference);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Conference conference)
    {
        var excistingConference = _conferences.FirstOrDefault(c => c.Id == conference.Id);
        if (excistingConference != null)
        {
            _conferences.Remove(excistingConference);
            _conferences.Add(conference);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Conference conference)
    {
        _conferences.Remove(conference);
        return Task.CompletedTask;
    }
}