using Confab.Shared.Abstractions;

namespace Confab.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrenDate()
    {
        return DateTime.UtcNow;
    }
}