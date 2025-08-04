using System;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Users.Core.Exceptions;

internal class UserNotActiveException(Guid userId) : ConferenceAppException($"User with ID: '{userId}' is not active.")
{
    public Guid UserId { get; } = userId;
}