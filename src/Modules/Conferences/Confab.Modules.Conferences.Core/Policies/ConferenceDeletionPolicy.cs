using Confab.Modules.Conferences.Core.Entities;
using Confab.Shared.Abstractions;

namespace Confab.Modules.Conferences.Core.Policies;

internal class ConferenceDeletionPolicy(IClock clock) : IConferenceDeletionPolicy
{
    public async Task<bool> CanDeleteAsync(Conference conference)
    {
        // TODO: check if there any participants?
        var canDelete = clock.CurrenDate().Date.AddDays(7) < conference.From.Date;

        return canDelete;
    }
}