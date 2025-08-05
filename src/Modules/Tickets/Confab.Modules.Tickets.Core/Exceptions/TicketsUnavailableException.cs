using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Tickets.Core.Exceptions;

public class TicketsUnavailableException(Guid conferenceId)
    : ConfabException("There are no available tickets for the conference.")
{
    public Guid ConferenceId { get; } = conferenceId;
}