using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions;

internal class HostNotFoundException(Guid id) : ConfabException($"Host with ID '{id}' was not found.")
{
    
}