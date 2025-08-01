using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions;

internal class CanNotDeleteConferenceException(Guid conferenceId)
    : ConferenceAppException($"Conference with ID '{conferenceId}' can not be deleted.");