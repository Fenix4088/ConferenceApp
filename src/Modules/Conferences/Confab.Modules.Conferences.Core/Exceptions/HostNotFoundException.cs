using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions;

internal class HostNotFoundException(Guid id) : ConferenceAppException($"Host with ID '{id}' was not found.")
{
    
}