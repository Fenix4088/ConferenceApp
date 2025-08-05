using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions;

internal class ConferenceNotFoundException(Guid conferenceId)
    : ConfabException($"Conference with ID '{conferenceId}' was not found.");