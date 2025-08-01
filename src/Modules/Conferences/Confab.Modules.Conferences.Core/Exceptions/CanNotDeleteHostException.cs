using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions;

public class CanNotDeleteHostException(Guid id)
    : ConferenceAppException($"Host with ID '{id}' cannot be deleted because it has associated conferences.");